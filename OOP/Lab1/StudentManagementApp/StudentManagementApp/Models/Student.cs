namespace StudentManagementApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public int FacultyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfEnrolment { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsGraduated { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}\n" +
                   $"Date of Birth: {DateOfBirth}\n" +
                   $"Email Address: {EmailAddress}\n" +
                   $"Date of Enrolement: {DateOfEnrolment}.\n" +
                   $"Graduated: " + (IsGraduated ? "Yes" : "No");
        }
    }
}
