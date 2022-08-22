using CollegeSystem.Models;
using CollegeSystem.Reporisatry;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : Controller
    {

       SearchRepo search = new SearchRepo();  

      [HttpPost("CreateSchedule")]  
      public IActionResult CreateSchedule([FromBody]Schedule schedule )
      {
            if (search.IsScheduleExits(schedule.studentId, schedule.type) != null)
                return BadRequest(new { message = "Schedule is aleardy exits" });
            DataBaseObject.db.schedules.Add(schedule);
            DataBaseObject.db.SaveChanges();
            return Ok(new { message = "Schedule added successfully", schedule = schedule });
      }
      [HttpDelete("DeleteSchedule")]
      public IActionResult DeleteSchedule(int scheduleID)
      {
            var schedule = search.SearchAboutScheduleById(scheduleID);
            if (schedule == null)
                return NotFound(new { message = "Schedule not found" });
            DataBaseObject.db.schedules.Remove(schedule);
            DataBaseObject.db.SaveChanges();
            return Ok(new { message = "Schedule deleted successfully" });
      }
      [HttpDelete("EditSchedule")]
       public IActionResult EditSchedule([FromBody]Schedule schedule)
       {
            var currentSchedule = search.SearchAboutScheduleById(schedule.id);
            if (currentSchedule == null)
                return NotFound(new { message = "Schedule not found" });
            if(search.IsScheduleExits(schedule.studentId,schedule.type)!=null)
                return BadRequest(new { message = "Schedule is aleardy exits" });
            currentSchedule.type = schedule.type;
            currentSchedule.studentId = schedule.studentId;
            DataBaseObject.db.SaveChanges();
            return Ok(new { message = "Schedule edited successfully",schedule=currentSchedule });
       }
       [HttpGet("GetSchedule")]
       public IActionResult GetSchedule(int scheduleID)
       {
            var schedule = search.SearchAboutScheduleById(scheduleID);
            if (schedule == null)
                return NotFound(new { message = "Schedule not found" });
            return Ok(new { message = "Successed", schedule = schedule });
       }
    
    }
}
