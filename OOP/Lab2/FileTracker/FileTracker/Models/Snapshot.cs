namespace FileTracker.Models
{
    public class Snapshot
    {
        public List<TrackedFile> Files { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}