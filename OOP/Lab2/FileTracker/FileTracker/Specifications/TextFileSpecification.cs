namespace FileTracker.Specifications
{
    public class TextFileSpecification : ISpecification
    {
        public void PrintFileInfo(string filename)
        {
            int lineCount = GetLineCount(filename);
            if (lineCount >= 0)
            {
                Console.WriteLine($"Total number of lines in the file: {lineCount}");
            }

            int wordCount = GetWordCount(filename);
            if (wordCount >= 0)
            {
                Console.WriteLine($"Total number of words in the file: {wordCount}");
            }

            int characterCount = GetCharacterCount(filename);
            if (characterCount >= 0)
            {
                Console.WriteLine($"Total number of characters in the file: {characterCount}");
            }
        }

        private static int GetLineCount(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            return lines.Length;
        }

        private static int GetWordCount(string fileName)
        {
            try
            {
                string content = File.ReadAllText(fileName);
                string[] words = content.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                return words.Length;
            }
            catch
            {
                //in case of error
                return -1;
            }
        }

        private static int GetCharacterCount(string fileName)
        {
            try
            {
                string content = File.ReadAllText(fileName);
                return content.Length;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return -1;
            }
        }
    }
}