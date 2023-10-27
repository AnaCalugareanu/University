namespace FileTracker.Models
{
    public class Snapshot
    {
        public List<TrackedFile> TrackedFiles { get; set; }
        public DateTime SnapshotTime { get; set; } = DateTime.Now;
    }
}