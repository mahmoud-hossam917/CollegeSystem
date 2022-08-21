using CollegeSystem.Models;
using Microsoft.AspNetCore.Mvc;
using CollegeSystem.Reporisatry;
using AutoMapper;

namespace CollegeSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
      
        SearchRepo search = new SearchRepo();
        private readonly IMapper _mapper;

        public AdminController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent([FromBody] StudentModel studentModel)
        {
            var isExit = search.SearchUserEmail(studentModel.email);
            if (isExit!=null) return NotFound("User is already exits");
            User user = new Student();
            user.email = studentModel.email;
            user.password = studentModel.password;
            user.role = "user";
            user.Createdon = DateTime.UtcNow;
            DataBaseObject.db.users.Add(user);
            DataBaseObject.db.SaveChanges();
            return Ok(new { email = user.email, password = user.password });
        }
        [HttpPost("SearchAboutUserById")]
        public IActionResult SearchAboutUserById(int id)
        {
            var user = search.SearchUserId(id);
            if (user!=null) return Ok(new{student= user});

            return NotFound("User not found");
        }
        
        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteStudent(int id)
        {
            var user = search.SearchUserId(id);
            if (user==null) return BadRequest("User not found");
            DataBaseObject.db.users.Remove(user);
            DataBaseObject.db.SaveChanges();
            return Ok("User has been Deleted");
        }
        [HttpPost("SearchAboutUserByName")]
        public IActionResult SearchAboutUserByName(string name)
        {
            var user = search.SearchUserName(name);
            if (user == null) return NotFound(new {message= "User not found"});
            return Ok(new { student = user });

        }
        [HttpPost("SearchAboutUserByEmail")]
        public IActionResult SearchAboutUserByEmail(string email)
        {
            var user = search.SearchUserEmail(email);
            if (user == null) return NotFound(new { message = "User not found" });
           
            return Ok(new { student = user });

        }
        [HttpPost("AddSubjectToStudent")]
        public IActionResult AddSubjectToStudent([FromBody] StudentSubject studentSubject)
        {
            var subjectExits=search.SearchSubjectInStudent(studentSubject);
            var student = search.SearchUserId(studentSubject.studentID);
            var subject = search.SearchSubjectById(studentSubject.subjectID);
            if (subjectExits != null||student==null||subject==null) 
                return BadRequest(new {message= "This subject is aleardy exits"});

            DataBaseObject.db.studentSubjects.Add(studentSubject);
            DataBaseObject.db.SaveChanges();
            return Ok(new { message = "subject Added" });
        }
        [HttpDelete("DeleteSubjectFromStudent")]
        public IActionResult DeleteSubjectFromStudent(int studentId, int subjectId)
        {
            StudentSubject studentSubject = new StudentSubject();
            studentSubject.studentID = studentId;
            studentSubject.subjectID = subjectId;
            var isExits = search.SearchSubjectInStudent(studentSubject);
            if (isExits == null) return BadRequest(new { message = "There is no subject" });
            DataBaseObject.db.studentSubjects.Remove(isExits);
            DataBaseObject.db.SaveChanges();
            return Ok(new { message = "Subject deleted" });
        }

    }
}
