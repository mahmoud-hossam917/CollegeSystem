namespace CollegeSystem.Models
{
    public class Schedule
    {
        public int id { get; set; }
        public int studentId { get; set; }
        public string type { get; set; }
        public List<AcademicDay> days { get; set; }
    }
}
