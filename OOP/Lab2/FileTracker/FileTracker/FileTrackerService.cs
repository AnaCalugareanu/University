using FileTracker.Models;

namespace FileTracker
{
    public class FileTrackerService
    {
        public static Snapshot Snapshot { get; set; }

        public FileTrackerService()
        {
            var watcher = new FileSystemWatcher(@"C:\UniLaboratory");

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
            Snapshot.TrackedFiles.FirstOrDefault(x => x.Name == e.Name).FileStatus = FileStatus.Changed;
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

        public TrackedFile GetInfoOnFiles()
        {
            TrackedFile trackedFile = new TrackedFile();

            return trackedFile;
        }

        public void GetStatus()
        {
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
    }
}