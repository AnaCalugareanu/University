namespace FileTracker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var tracker = new FileTrackerService();

            while (true)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                Console.Write("What can we do for you?\n" +
                              "1 - Commit.\n" +
                              "2 - Info <filename>.\n" +
                              "3 - Status. \n" +
                              "ENTER - Quit program.\n" +
                              "Choose a number : ");
                var user = Console.ReadLine();
                int.TryParse(user, out int number);

                switch (number)
                {
                    case 1:
                        tracker.Commit();
                        break;

                    case 2:
                        tracker.GetInfoOnFiles();
                        break;

                    case 3:
                        tracker.GetStatus();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}