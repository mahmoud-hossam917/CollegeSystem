using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public int academicYear { get; set; }
        public DateTime lectureDate { get; set; }
        public DateTime examDate { get; set; }
        public int term { get; set; }
        public List<StudentSubject>? students { get; set; }
        public List<SubjectDay> days { get; set; }
    }
}
