using System.ComponentModel.DataAnnotations;

namespace CollegeSystem.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        
        public string? name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int? age { get; set; }
        public string? phoneNumber { get; set; }
        public DateTime? Createdon { get; set; }
        public string role { get; set; }
        public  string? gender { get; set; }
    }
}
