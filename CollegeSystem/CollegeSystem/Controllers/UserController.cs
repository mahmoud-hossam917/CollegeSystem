using CollegeSystem.Helper;
using CollegeSystem.Reporisatry;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller 
    {

       
       SearchRepo search = new SearchRepo(); 
       public readonly JwtAuthanticationManager jwt;
       public UserController(JwtAuthanticationManager jwt)
       {
        this.jwt = jwt;
       }
        [HttpPost("Login")]
       public IActionResult Login(string email , string password)
       {
            var token=jwt.Authanticate(email, password);
            if (token == null) return NotFound(new { message = "Bad credentials!" });
            var user=search.IsUserExits(email, password);
            return Ok(new {token=token , user=user});


       }
    }
}
