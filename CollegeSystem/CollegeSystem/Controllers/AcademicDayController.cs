using CollegeSystem.Models;
using CollegeSystem.Reporisatry;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcademicDayController : Controller
    {

        SearchRepo search = new SearchRepo();
        [HttpPost("AddAcademicDay")]
        public IActionResult AddAcademicDay([FromBody] AcademicDay day)
        {
            if (search.IsDayExits(day.date, day.day, day.scheduleID) != null)
                return BadRequest(new { message = "Day is already exits" });
            DataBaseObject.db.days.Add(day);
            DataBaseObject.db.SaveChanges();
            return Ok(new { message = "Added successfully" });
        }
        [HttpDelete("DeleteDay")]
        public IActionResult DeleteDay(int id)
        {
            var day = search.SearchAboutDaybyId(id);
            if (day == null)
                return NotFound(new { message = "Day is not found" });
            DataBaseObject.db.days.Remove(day);
            DataBaseObject.db.SaveChanges();
            return Ok(new { message = "Deleted successfully" });
        }
        [HttpPost("EditDay")]
        public IActionResult EditDay([FromBody] AcademicDay day)
        {
            var currentDay = search.SearchAboutDaybyId(day.id);
            if (currentDay == null)
                return NotFound(new { message = "Not found" });
            currentDay.date = day.date;
            currentDay.day = day.day;
            currentDay.scheduleID = day.scheduleID;
            if (search.IsDayExits(currentDay.date, currentDay.day, currentDay.scheduleID) != null)
            {
                DataBaseObject.db.Dispose();
                return BadRequest(new { message = "Day is already exits" });
            }

            DataBaseObject.db.SaveChanges();
            return Ok(new { message = "Edited successfully", day = currentDay });

        }
    }
}
