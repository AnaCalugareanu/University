using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;
using StudentManagementApp.Models;

namespace StudentManagementApp.Processors
{
    public class FacultyProcessor
    {
        string input;

        private readonly StudentManagementDbContext context;
        private readonly ILogger logger;

        public FacultyProcessor(StudentManagementDbContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public void SetFacultyData()
        {
            Faculty faculty = new Faculty();

            SetFacultyName(faculty);
            SetFacultyAbbreviation(faculty);
            SetFacultyStudyField(faculty);

            context.Faculties.Add(faculty);
            context.SaveChanges();

            logger.LogInformation($"New Faculty Created: {faculty.Name}({faculty.Abbreviation})");

            Console.WriteLine("Succesfully created the faculty.");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
        }

        private void SetFacultyName(Faculty faculty)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            bool result;
            Console.WriteLine("What is the name of the faculty?");
            do
            {
                input = Console.ReadLine().Trim();
                result = !string.IsNullOrWhiteSpace(input) && input.All(x => char.IsLetter(x) || char.IsWhiteSpace(x));
                if (!result)
                {
                    Console.WriteLine($"Faculty name should only contain letters. Try Again");
                }
            } while (!result);

            faculty.Name = input;
        }

        private void SetFacultyAbbreviation(Faculty faculty)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            bool isUpper;
            Console.WriteLine("What is the faculty abreviation?");
            do
            {
                input = Console.ReadLine().Trim();
                isUpper = !string.IsNullOrWhiteSpace(input) && input.All(x => char.IsUpper(x) && input.Length <= 5);
                if (!isUpper)
                {
                    Console.WriteLine($"Faculty abbreviation should only contain up to 5 capital letters. Try Again");
                }
            } while (!isUpper);

            faculty.Abbreviation = input;
        }

        private void SetFacultyStudyField(Faculty faculty)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Choose the number of your faculty study field? \n" +
                  "1 - Mecanical Engineering \n" +
                  "2 - Software Engineering \n" +
                  "3 - Food Technology \n" +
                  "4 - Ubanism Architecture \n" +
                  "5 - Veterinary Medicine \n");
            Console.Write("Enter the number :");

            bool isParsed;
            StudyField value;

            do
            {
                input = Console.ReadLine();
                int.TryParse(input, out int number);
                isParsed = Enum.TryParse(input, out value) && number <= 5 && number >= 1;
                if (!isParsed)
                {
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("The number you chose is not on the list, choose again wisely ! \n" +
                              "1 - Mecanical Engineering \n" +
                              "2 - Software Engineering \n" +
                              "3 - Food Technology \n" +
                              "4 - Ubanism Architecture \n" +
                              "5 - Veterinary Medicine \n");
                    Console.Write("Enter the number :");
                }

            } while (!isParsed);

            faculty.StudyField = value;
        }

        public void SearchFacultyByStudentEmail()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Enter the email address of the student: ");
            var emailAddress = Console.ReadLine();

            var student = context.Students.FirstOrDefault(x => x.EmailAddress == emailAddress);
            if (student == null)
            {
                logger.LogInformation($"Student not found with following email: {emailAddress}");
                Console.WriteLine("Sorry. The student was not found.");
                return;
            }

            var faculty = context.Faculties.FirstOrDefault(x => x.FacultyId == student.FacultyId);

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"The student belongs to {faculty.Name}.");
        }
        public void SearchFacultyByStudyField()
        {
            bool isParsed;
            StudyField value;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Choose the number of the Study Field you are looking for. \n" +
                          "1 - Mecanical Engineering \n" +
                          "2 - Software Engineering \n" +
                          "3 - Food Technology \n" +
                          "4 - Ubanism Architecture \n" +
                          "5 - Veterinary Medicine \n");
            Console.Write("Enter the number :");
            input = Console.ReadLine();

            int.TryParse(input, out int number);
            isParsed = Enum.TryParse(input, out value) && number <= 5 && number >= 1;
            if (!isParsed)
            {
                logger.LogInformation($"Invalid input for study fields was provided: {value}");

                Console.WriteLine("There is no such Study Field.");
                return;
            }

            var facultiesByStudyField = context.Faculties.Where(x => x.StudyField == value).ToList();
            if (facultiesByStudyField.Count == 0)
            {
                logger.LogInformation($"Faculties not found with following study fields: {value}");

                Console.WriteLine("There are no faculties in this field");
            }

            foreach (var fac in facultiesByStudyField)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(fac.ToString());
            }

        }

        public void DisplayFaculties()
        {
            var faculties = context.Faculties.ToList();

            foreach (var fac in faculties)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(fac.ToString());
            }
        }
    }
}
