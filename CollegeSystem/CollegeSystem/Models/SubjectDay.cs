using System.Text.Json.Serialization;

namespace CollegeSystem.Models
{
    public class SubjectDay
    {
        public int dayID { get; set; }
        [JsonIgnore]
        public AcademicDay AcademicDay { get; set; }
        public int subjectID { get; set; }
        [JsonIgnore]
        public Subject Subject { get; set; }

    }
}
