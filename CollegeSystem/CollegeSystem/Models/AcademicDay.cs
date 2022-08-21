namespace CollegeSystem.Models
{
    public class AcademicDay
    {
        public int id { get; set; }
        public int scheduleID { get; set; }
        public string day { get; set; }
        public DateTime date { get; set; }
        public List<Subject> subjects { get; set; }
    }
}
