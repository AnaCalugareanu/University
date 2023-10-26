namespace FileTracker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var tracker = new FileTrackerService();

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}