using System.Drawing;

namespace FileTracker.Specifications
{
    public class ImageFileSpecification : ISpecification
    {
        public void PrintFileInfo(string filename)
        {
            (int width, int height) = GetImageDimensions(filename);

            if (width >= 0 && height >= 0)
            {
                Console.WriteLine($"Image dimensions: {width} x {height} pixels");
            }
        }

        private static (int, int) GetImageDimensions(string fileName)
        {
            Bitmap size = null;

            try
            {
                Bitmap bitmap = new(fileName);
                size = bitmap;
                return (size.Width, size.Height);
            }
            catch (Exception exeption)
            {
                Console.WriteLine("An error occurred: " + exeption.Message);
                return (-1, -1);
            }
            finally
            {
                size?.Dispose();
            }
        }
    }
}