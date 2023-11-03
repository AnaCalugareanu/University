using FileTracker.Models;

namespace FileTracker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string directory = @"C:\UniLaboratory";
            var snapshot = new Snapshot();
            string[] files = Directory.GetFiles(directory);
            foreach (var element in files)
            {
                snapshot.TrackedFiles.Add(new TrackedFile
                {
                    Name = element.Split('\\')[2],
                    FileStatus = FileStatus.Unchanged
                });
            }

            var tracker = new FileTrackerService();

            FileTrackerService.Snapshot = snapshot;

            while (true)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                Console.Write("What can we do for you?\n" +
                              "1 - Commit.\n" +
                              "2 - Info <filename>.\n" +
                              "3 - Status. \n" +
                              "9 - Quit program.\n" +
                              "Choose a number : ");
                var user = Console.ReadLine();
                int.TryParse(user, out int number);

                switch (number)
                {
                    case 1:
                        Console.WriteLine(tracker.Commit());
                        tracker.ResetSnapshot();
                        break;

                    case 2:
                        tracker.GetInfoOnFiles();
                        break;

                    case 3:
                        tracker.GetStatus();
                        break;

                    case 9:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("The number you entered is not on the list.");
                        break;
                }
            }
        }
    }
}