namespace StudentManagementApp.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public StudyField StudyField { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public override string ToString()
        {
            return $"Faculty Name: {Name},\n" +
                   $"Faculty Abbreviation: {Abbreviation}, \n" +
                   $"Study Field: {StudyField} \n";
        }
    }
}
