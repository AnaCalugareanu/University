using Microsoft.Extensions.Logging;
using StudentManagementApp.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;
using System.Globalization;

namespace StudentManagementApp.Processors
{
    public class StudentProcessor
    {
        private readonly StudentManagementDbContext context;
        private readonly ILogger logger;
        string input;

        public StudentProcessor(StudentManagementDbContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public void SetStudentInfo()
        {
            Student student = new Student();

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.Write("Student Infomation \n" +
                          "Student First Name: ");
            bool name;
            do
            {
                input = Console.ReadLine().Trim();
                name = !string.IsNullOrWhiteSpace(input) && input.All(x => char.IsLetter(x)) && char.IsUpper(input[0]);
                if (!name)
                {
                    Console.WriteLine("First Name should only contain letters, and should start with upper case. Try Again");
                }
            } while (!name);
            student.FirstName = input;

            Console.Write("Last Name: ");
            do
            {
                input = Console.ReadLine().Trim();
                name = !string.IsNullOrWhiteSpace(input) && input.All(x => char.IsLetter(x)) && char.IsUpper(input[0]);
                if (!name)
                {
                    Console.WriteLine("Last Name should only contain letters, and should start with upper case. Try Again");
                }
            } while (!name);
            student.LastName = input;

            bool email;
            Console.Write("Email Address: ");
            do
            {
                input = Console.ReadLine();
                var emailValidation = new EmailAddressAttribute();
                email = emailValidation.IsValid(input);
                if (!email)
                {
                    Console.WriteLine("This is not a valid email address. Try Again");
                }
            } while (!email);
            student.EmailAddress = input;

            int result;
            DateTime dateOfBirth;
            Console.Write("Date Of Birth (as month/day/year): ");
            do
            {
                DateTime.TryParse(Console.ReadLine(), out dateOfBirth);
                result = DateTime.Compare(dateOfBirth, DateTime.Now);
                if (result >= 0)
                {
                    Console.WriteLine("Not valid date. Try Again");
                }

            } while (result >= 0);
            student.DateOfBirth = dateOfBirth;

            Console.Write("Date of enrolement (as month/day/year): ");
            DateTime dateOfEnrolment;
            do
            {
                DateTime.TryParse(Console.ReadLine(), out dateOfEnrolment);
                result = DateTime.Compare(dateOfEnrolment, DateTime.Now);
                if (result >= 0)
                {
                    Console.WriteLine("Not valid date. Try Again");
                }
            } while (result >= 0);
            student.DateOfEnrolment = dateOfEnrolment;

            bool isUpper;
            int? facultyId = null;
            Console.WriteLine("What is the faculty abreviation that the student belongs to?");
            do
            {
                input = Console.ReadLine();
                isUpper = !string.IsNullOrWhiteSpace(input) && input.All(x => char.IsUpper(x) && input.Length <= 5);
                if (!isUpper)
                {
                    Console.WriteLine($"Faculty abbreviation should only contain up to 5 capital letters. Try Again");
                }
                else
                {
                    facultyId = context.Faculties.FirstOrDefault(x => x.Abbreviation == input)?.FacultyId;
                    if (facultyId == null)
                    {
                        Console.WriteLine("Faculty not found, try again.");
                        isUpper = false;
                    }
                }
            } while (!isUpper);

            student.FacultyId = facultyId.GetValueOrDefault();

            context.Students.Add(student);
            context.SaveChanges();

            logger.LogInformation($"New student created: {student.FirstName} {student.LastName}, {student.EmailAddress}");

            Console.WriteLine("Student succesfully created");
        }

        public void DisplayStudentInfo(bool graduated = false)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("What is the abbreviation of the faculty you are looking for? ");
            input = Console.ReadLine();

            var faculty = context.Faculties.FirstOrDefault(x => x.Abbreviation == input);

            if (faculty == null)
            {
                Console.WriteLine("The faculty was not found.");
                return;
            }

            // filter students based on graduation status
            var students = faculty.Students.Where(x => x.IsGraduated == graduated);

            if(!students.Any())
            {
                Console.WriteLine("No students found");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                return;
            }

            Console.WriteLine("The students you are looking for are");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            foreach (var stud in students)
            {
                Console.WriteLine(stud.ToString());
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

        }

        public void GraduateStudent()
        {
            Console.WriteLine("Enter the email address of the student you want to graduate: ");
            var emailAddress = Console.ReadLine();

            var student = context.Students.FirstOrDefault(x => x.EmailAddress == emailAddress);

            if (student == null)
            {
                logger.LogInformation($"Student not found for the following email: {emailAddress}");

                Console.WriteLine("Sorry. The student was not found.");
                return;
            }

            if (!student.IsGraduated)
            {
                student.IsGraduated = true;
                context.Students.Update(student);
                context.SaveChanges();

                logger.LogInformation($"Student graduated: {emailAddress}");

                Console.WriteLine("Successfully graduated the student");
                return;
            }

            logger.LogInformation($"Tried to graduate student: {emailAddress} but he has already graduated");

            Console.WriteLine("The student already graduated.");
        }

        public void DetermineIfStudentInFaculty()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("What is the Faculty Abbreviation that the student belongs to?");
            var facultyAbv = Console.ReadLine();

            Console.WriteLine("Enter the email address of the student you want to find: ");
            var emailAddress = Console.ReadLine();

            var student = context.Faculties.FirstOrDefault(x => x.Abbreviation == facultyAbv).Students.FirstOrDefault(x => x.EmailAddress == emailAddress);

            if (student == null)
            {
                logger.LogInformation($"Student not found for email: {emailAddress}");

                Console.WriteLine("Sorry. The student was not found.");
                return;
            }

            if (student.IsGraduated == true)
            {
                Console.WriteLine("The student has graduated this faculty.");
                return;
            }

            Console.WriteLine($"The student belongs to {facultyAbv}.");
        }

        public void BatchEnrollmentOfStudents()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Please write the path for the file for batch enrollment:");
            Console.WriteLine("Each new student should be written from new line with the following format:");
            Console.WriteLine("First Name,Last Name,E-mail,Faculty Abbreviation,Date of Birth,Date of enrollment:");

            var filePath = Console.ReadLine();

            List<Student> students = new List<Student>();
            var faculties = context.Faculties.ToList();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (var row in lines)
                {

                    string[] columns = row.Split(',');

                    string firstName = columns[0];
                    string lastName = columns[1];
                    string email = columns[2];
                    string abbreviation = columns[3];
                    bool result1 = DateTime.TryParse(columns[4], out DateTime dateOfBirth);
                    bool result2 = DateTime.TryParse(columns[4], out DateTime dateOfEnrollment);

                    if (result1 == false || result2 == false)
                        throw new Exception();

                    students.Add(new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        EmailAddress= email,
                        FacultyId = faculties.FirstOrDefault(x => x.Abbreviation == abbreviation).FacultyId,
                        DateOfBirth= dateOfBirth,
                        DateOfEnrolment= dateOfEnrollment
                    });

                }
                logger.LogInformation($"Batch enrollment successful with a total of {students.Count} students");


            }
            catch (Exception ex)
            {
                logger.LogError($"Batch Enrollment Failed, exiting: {ex.Message}");
                Console.WriteLine("Batch Enrollment failed for some or all students, wrong data found file");
            }
            finally
            {
                if (students.Count > 0) 
                {
                    context.AddRange(students);
                    context.SaveChanges();
                    Console.WriteLine($"{students.Count} students added");
                }
            }

            

            
        }

        public void BatchGraduationOfStudents()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Please write the path for the file for batch graduation:");
            Console.WriteLine("The format should be email followed by a comma");


            var filePath = Console.ReadLine();

            var students = context.Students.ToList();
            int studentsGraduated = 0;
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (var row in lines)
                {

                    string[] columns = row.Split(',');
                    foreach (var element in columns)
                    {
                        students.FirstOrDefault(x => x.EmailAddress == element).IsGraduated = true;
                        studentsGraduated += 1;
                    }

                }
                logger.LogInformation($"Batch graduation successful with a total of {students.Count} students graduated");

            }
            catch (Exception ex)
            {
                logger.LogError($"Batch Graduation Failed, exiting: {ex.Message}");
                Console.WriteLine("Batch Graduation failed for some or all students, wrong email found in file");
            }
            finally
            {
                context.UpdateRange(students);
                context.SaveChanges();
                Console.WriteLine($"{studentsGraduated} students graduated");
            }
        }
    }
}
