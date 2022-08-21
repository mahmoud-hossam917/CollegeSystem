namespace CollegeSystem.Models
{
    public class Schedule
    {
        public int id { get; set; }
        public int studentId { get; set; }
        public int type { get; set; }
        public List<AcademicDay> days { get; set; }
    }
}
