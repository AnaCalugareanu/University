using Microsoft.Extensions.Logging;
using StudentManagementApp;
using StudentManagementApp.Processors;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddEventLog();
});

FacultyProcessor facultyProcessor = new FacultyProcessor(new StudentManagementDbContext(), loggerFactory.CreateLogger<FacultyProcessor>());
StudentProcessor studentProcessor = new StudentProcessor(new StudentManagementDbContext(), loggerFactory.CreateLogger<StudentProcessor>());

Console.WriteLine("Hi, this is TUM's Student Management System!");

while (true)
{
    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
    Console.Write("What can we do for you?\n" +
                  "1 - General operations.\n" +
                  "2 - Faculty operations.\n" +
                  "9 - Quit program.\n" +
                  "Choose a number : ");
    var user = Console.ReadLine();
    int.TryParse(user, out int number);

    switch (number)
    {
        case 1:
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.Write("General operations:\n" +
                          "1 - Create a new faculty.\n" +
                          "2 - Search what faculty a student belongs to by email.\n" +
                          "3 - Display University faculties.\n" +
                          "4 - Display all faculties belonging to a field.\n" +
                          "8 - Go Back.\n" +
                          "9 - Quit program.\n" +
                          "Choose a number : ");
            user = Console.ReadLine();
            int.TryParse(user, out int chosenNumber);
            switch (chosenNumber)
            {
                case 1:
                    facultyProcessor.SetFacultyData();
                    break;
                case 2:
                    facultyProcessor.SearchFacultyByStudentEmail();
                    break;
                case 3:
                    facultyProcessor.DisplayFaculties();
                    break;
                case 4:
                    facultyProcessor.SearchFacultyByStudyField();
                    break;
                case 8:
                    continue;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("The number you entered is not on the list.");
                    break;
            }
            break;

        case 2:
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.Write("Faculty operations:\n" +
                          "1 - Create and assign a student to a faculty.\n" +
                          "2 - Graduate a student from a faculty.\n" +
                          "3 - Display current enrolled students.\n" +
                          "4 - Display graduates.\n" +
                          "5 - Tell or not if a student belongs to this faculty.\n" +
                          "6 - Batch Enroll Students.\n" +
                          "7 - Batch Graduate Students.\n" +
                          "8 - Go Back.\n" +
                          "9 - Quit program.\n" +
                          "Choose a number : ");
            user = Console.ReadLine();
            int.TryParse(user, out int userInput);
            switch (userInput)
            {
                case 1:
                    studentProcessor.SetStudentInfo();
                    break;
                case 2:
                    studentProcessor.GraduateStudent();
                    break;
                case 3:
                    studentProcessor.DisplayStudentInfo();
                    break;
                case 4:
                    studentProcessor.DisplayStudentInfo(true);
                    break;
                case 5:
                    studentProcessor.DetermineIfStudentInFaculty();
                    break;
                case 6:
                    studentProcessor.BatchEnrollmentOfStudents();
                    break;
                case 7:
                    studentProcessor.BatchGraduationOfStudents();
                    break;
                case 8:
                    continue;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("The number you entered is not on the list.");
                    break;
            }
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

