using FileTracker.Specifications;

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
                              "9 - Quit program.\n" +
                              "Choose a number : ");
                var user = Console.ReadLine();
                int.TryParse(user, out int number);

                switch (number)
                {
                    case 1:
                        tracker.Commit();
                        break;

                    case 2:
                        //tracker.GetInfoOnFiles();
                        var dsadas = new ProgramFileSpecification();
                        dsadas.PrintFileInfo(@"C:\main.py");
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