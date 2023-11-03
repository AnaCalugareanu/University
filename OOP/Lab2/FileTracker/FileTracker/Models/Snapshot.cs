namespace FileTracker.Models
{
    public class Snapshot
    {
        public List<TrackedFile> TrackedFiles { get; set; } = new List<TrackedFile>();
        public DateTime SnapshotTime { get; set; } = DateTime.Now;

        public string ListToString(List<TrackedFile> files)
        {
            string output = string.Empty;

            foreach (var file in files)
            {
                output += $"{file.Name} - {file.FileStatus}\n";
            }

            return output;
        }

        public override string ToString()
        {
            return $"Craete new snapshot at: {SnapshotTime}:\n" + ListToString(TrackedFiles);
        }
    }
}