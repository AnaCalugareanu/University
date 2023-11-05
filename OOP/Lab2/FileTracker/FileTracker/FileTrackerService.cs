using FileTracker.Models;
using FileTracker.Specifications;

namespace FileTracker
{
    public class FileTrackerService
    {
        public static Snapshot Snapshot { get; set; }
        private static DateTime lastRead = DateTime.MinValue;
        private const string FOLDER_PATH = @"C:\UniLaboratory\";
        private static List<string> updatesToPrint = new List<string>();

        public FileTrackerService()
        {
            var watcher = new FileSystemWatcher(FOLDER_PATH);

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
                updatesToPrint.Add($"{e.Name} has been updated");
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
            updatesToPrint.Add($"{e.Name} has been added");
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Snapshot.TrackedFiles.FirstOrDefault(x => x.Name == e.Name).FileStatus = FileStatus.Deleted;
            updatesToPrint.Add($"{e.Name} has been deleted");
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Snapshot.TrackedFiles.FirstOrDefault(x => x.Name == e.Name).FileStatus = FileStatus.Renamed;
            updatesToPrint.Add($"{e.Name} has been renamed");
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

            var filePath = FOLDER_PATH + fileName;

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

        public static async Task RunInBackground(TimeSpan timeSpan)
        {
            var periodicTimer = new PeriodicTimer(timeSpan);
            while (await periodicTimer.WaitForNextTickAsync())
            {
                foreach (var update in updatesToPrint)
                    Console.WriteLine(update);

                updatesToPrint = new List<string>();
            }
            
        }
    }
}