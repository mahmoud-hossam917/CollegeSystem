namespace CollegeSystem.Models
{
    public class Student:User
    {
        public int academicYear { get; set; }
        public int classNumber { get; set; }
        public List<StudentSubject>?subjects { get; set; }
    }
}
