using FileTracker.Models;
using FileTracker.Specifications;

namespace FileTracker
{
    public class FileTrackerService
    {
        public static Snapshot Snapshot { get; set; }
        private static DateTime lastRead = DateTime.MinValue;
        private const string FolderPath = @"C:\UniLaboratory\";

        public FileTrackerService()
        {
            var watcher = new FileSystemWatcher(FolderPath);

            watcher.NotifyFilter = NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;

            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            //this logic was done because common file editors send 2 notifications instead of 1 on file modification.
            DateTime lastWriteTime = File.GetLastWriteTime(e.FullPath);
            if (lastWriteTime != lastRead)
            {
                Snapshot.TrackedFiles.FirstOrDefault(x => x.Name == e.Name).FileStatus = FileStatus.Changed;
                Console.WriteLine(e.Name + "has been modified");
                lastRead = lastWriteTime;
            }
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Snapshot.TrackedFiles.Add(new TrackedFile
            {
                Name = e.Name,
                FileStatus = FileStatus.Added
            });
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Snapshot.TrackedFiles.FirstOrDefault(x => x.Name == e.Name).FileStatus = FileStatus.Deleted;
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Snapshot.TrackedFiles.FirstOrDefault(x => x.Name == e.Name).FileStatus = FileStatus.Renamed;
        }

        public Snapshot Commit()
        {
            Snapshot.SnapshotTime = DateTime.Now;
            return Snapshot;
        }

        public void GetInfoOnFiles()
        {
            Console.Write("Introduce the file name: ");
            var fileName = Console.ReadLine();

            var filePath = FolderPath + fileName;

            var specification = GetSpecification(filePath.Split('.')[1]);

            specification.PrintFileInfo(filePath);

            return;
        }

        public void GetStatus()
        {
            Console.WriteLine("Status of files after the latest snapshot:");
            Console.WriteLine(Snapshot.ListToString(Snapshot.TrackedFiles));
        }

        public void ResetSnapshot()
        {
            foreach (var file in Snapshot.TrackedFiles)
            {
                if (file.FileStatus == FileStatus.Deleted)
                {
                    Snapshot.TrackedFiles.Remove(file);
                    break;
                }

                file.FileStatus = FileStatus.Unchanged;
            }
        }

        private ISpecification GetSpecification(string fileExtension)
        {
            if (fileExtension == "py" ||
               fileExtension == "c")
                return new ProgramFileSpecification();

            if (fileExtension == "txt")
                return new TextFileSpecification();

            if (fileExtension == "jpg" ||
               fileExtension == "png" ||
               fileExtension == "jpeg")
                return new ImageFileSpecification();

            return new GenericFileSpecification();
        }
    }
}