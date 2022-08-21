using CollegeSystem.Models;
using CollegeSystem.Reporisatry;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
       
       SearchRepo search = new SearchRepo(); 
       [HttpPost("EditStudent")]
       public IActionResult EditStudent([FromBody]UpdateStudent newStudent, int id)
       {
                            
            var student = search.SearchUserId(id);
            if (student == null) return BadRequest(new { message = "User not found" });
            student.phoneNumber = newStudent.phoneNumber;
            student.gender = newStudent.gender;
            student.age = newStudent.age;
            student.academicYear = newStudent.academicYear;
            student.classNumber = newStudent.classNumber;
            student.name = newStudent.name;
            student.password = newStudent.password;
            DataBaseObject.db.SaveChanges();
            return Ok(new { student = student });

       }

    }
}
