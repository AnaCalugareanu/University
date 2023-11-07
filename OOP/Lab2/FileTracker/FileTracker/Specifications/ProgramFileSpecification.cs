using FileTracker.Helpers;

namespace FileTracker.Specifications
{
    public class ProgramFileSpecification : ISpecification
    {
        public void PrintFileInfo(string filename)
        {
            string[] fileExtensions = { ".py", ".java" };
            string extension = Path.GetExtension(filename);
            if (extension == fileExtensions[0] || extension == fileExtensions[1])
            {
                int lineCount = CountLinesInFile(filename);
                if (lineCount >= 0)
                {
                    Console.WriteLine($"Total number of lines in the file: {lineCount}");
                }

                if (extension == fileExtensions[0])
                {
                    Console.WriteLine(ProgramFileSpecHelper.CountClassesInPython(filename));
                    Console.WriteLine(ProgramFileSpecHelper.CountMethodsInPython(filename));
                }
                else if (extension == fileExtensions[1])
                {
                    Console.WriteLine(ProgramFileSpecHelper.CountClassesInJava(filename));
                    Console.WriteLine(ProgramFileSpecHelper.CountMethodsInJava(filename));
                }
                else
                {
                    Console.WriteLine("Error. File not valid.");
                }
            }
        }

        private static int CountLinesInFile(string fileName)
        {
            try
            {
                int lineCount = 0;
                using (StreamReader reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        reader.ReadLine();
                        lineCount++;
                    }
                }
                return lineCount;
            }
            catch (Exception exeption)
            {
                Console.WriteLine("An error occurred: " + exeption.Message);
                return -1;
            }
        }
    }
}