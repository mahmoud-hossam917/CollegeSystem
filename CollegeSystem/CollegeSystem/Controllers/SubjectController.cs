using CollegeSystem.Models;
using CollegeSystem.Reporisatry;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : Controller
    {
        SearchRepo search = new SearchRepo();
        [HttpPost("AddSubject")]
        public IActionResult AddSubject(Subject subject)
        {
            var isExits = search.SearchSubjectByName(subject.name);
            if (isExits != null) return BadRequest(new { message = "Subject aleardy exits" });

            DataBaseObject.db.subjects.Add(subject);
            DataBaseObject.db.SaveChanges();
            return Ok(new {subject = subject});
        }
        [HttpDelete("DeleteSubject")]
        public IActionResult DeleteSubject(int subjectId)
        {
            var isExits = search.SearchSubjectById(subjectId);
            if (isExits == null) return BadRequest(new { message = "Subject is not exits" });

            DataBaseObject.db.subjects.Remove(isExits);
            DataBaseObject.db.SaveChanges();
            return Ok(new { message="Subject Deleted" });
        }
        [HttpPut("EditSubject")]
        public IActionResult EditSubject(Subject subject)
        {
            var isExit = search.SearchSubjectById(subject.Id);
            if (isExit == null) return BadRequest(new { message = "Subject is not exits" });
            DataBaseObject.db.subjects.Update(subject);
            DataBaseObject.db.SaveChanges();
            return Ok(new { message = "Subject Updated" });
        }

    }
}
