namespace FileTracker.Models
{
    public class Snapshot
    {
        public List<TrackedFile> TrackedFiles { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}