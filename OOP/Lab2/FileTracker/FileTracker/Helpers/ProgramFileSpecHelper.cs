using System.Text.RegularExpressions;

namespace FileTracker.Helpers
{
    public static class ProgramFileSpecHelper
    {
        private static int CountBasedOnRegex(string fileName, string pattern)
        {
            try
            {
                string content = File.ReadAllText(fileName);
                MatchCollection matches = Regex.Matches(content, pattern);
                return matches.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return -1;
            }
        }

        public static string CountClassesInPython(string fileName)
        {
            return "Total Classes in file: " + CountBasedOnRegex(fileName, @"(\bclass\s+(\w+)\s*[:\(])");
        }

        public static string CountMethodsInPython(string fileName)
        {
            return "Total Methods in file: " + CountBasedOnRegex(fileName, @"(\bdef\s+\w+\s*\([^)]*\):)");
        }

        public static string CountClassesInJava(string fileName)
        {
            return "Total Classes in file: " + CountBasedOnRegex(fileName, @"(\b(class|interface)\s+(\w+)\s*)");
        }

        public static string CountMethodsInJava(string fileName)
        {
            return "Total Methods in file: " + CountBasedOnRegex(fileName, @"(\b(public|private|protected|static|\s) +[\w\<\>\[\]]+\s+(\w+) *\(.*?\)\s*(\{|\n))");
        }
    }
}