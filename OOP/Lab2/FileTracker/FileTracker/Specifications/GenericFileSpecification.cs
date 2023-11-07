namespace FileTracker.Specifications
{
    public class GenericFileSpecification : ISpecification
    {
        public void PrintFileInfo(string filename)
        {
            string name = GetFileName(filename);
            Console.WriteLine($"Filename : {name}");
            string extension = GetFileExtension(filename);
            Console.WriteLine($"Pretty print of file extension: {extension}");
            Console.WriteLine(GetFileDateTimeDetails(filename));
        }

        private static string GetFileName(string fileName)
        {
            string name = null;
            name = Path.GetFileName(fileName);

            return name;
        }

        private static string GetFileExtension(string fileName)
        {
            Dictionary<string, string> ExtensionMappings = new Dictionary<string, string>(){
                { ".csv" ," Comma - separated values file" },
                { ".docx", "Document File" },
                { ".pdf", "Document File" },
                { ".xlsx", "Spreadsheet File" },
                { ".pptx", "Presentation File" },
                { ".mp4", "Video File" }
             };
            string extension = Path.GetExtension(fileName);

            if (ExtensionMappings.ContainsKey(extension))
            {
                return ExtensionMappings[extension];
            }
            else
            {
                return "Unknown File Type";
            }
        }

        private static string GetFileDateTimeDetails(string fileName)
        {
            DateTime creation = File.GetCreationTime(fileName);
            DateTime modification = File.GetLastWriteTime(fileName);
            string dateTime = $"Creation Date and Time: {creation}\nFile updated : {modification}";

            return dateTime;
        }
    }
}