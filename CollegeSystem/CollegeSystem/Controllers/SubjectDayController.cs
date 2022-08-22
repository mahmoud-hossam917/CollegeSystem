using CollegeSystem.Models;
using CollegeSystem.Reporisatry;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectDayController : Controller
    {
        SearchRepo search = new SearchRepo();

        [HttpPost("AddSubjectInDay")]
        public IActionResult AddSubjectInDay([FromBody]SubjectDay subject)
        {
            if (search.SearchAboutSubjectInDay(subject.subjectID, subject.dayID) != null)
                return BadRequest(new { message = "Subject is already added in this day" });
            DataBaseObject.db.subjectDay.Add(subject);
            DataBaseObject.db.SaveChanges();
            return Ok(new { message = "Added successfully", subjec = subject });
        }
        [HttpDelete("DeleteSubjectFromDay")]
        public IActionResult DeleteSubjectFromDay(int subjectID ,int dayID)
        {
            var day=search.SearchAboutSubjectInDay(subjectID, dayID);
            if (day == null) 
                return BadRequest(new { message = "There is no subject in this day" });
            DataBaseObject.db.subjectDay.Remove(day);
            DataBaseObject.db.SaveChanges();
            return Ok(new { message = "Subject deleted successfully" });
        }


    }
}
