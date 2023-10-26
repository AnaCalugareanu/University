namespace FileTracker
{
    public class FileTrackerService
    {
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
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
        }
    }
}