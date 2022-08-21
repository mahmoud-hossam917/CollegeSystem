using System.Text.Json.Serialization;

namespace CollegeSystem.Models
{
    public class StudentSubject
    {
        public int studentID { get; set; }
        [JsonIgnore]
        public Student Student{ get; set; }
        public int subjectID { get; set; }
        [JsonIgnore]
        public Subject Subject{ get; set; }
    }
}
