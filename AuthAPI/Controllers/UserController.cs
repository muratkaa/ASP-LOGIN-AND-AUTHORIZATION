
/*using AuthAPI.Models;
using AuthAPI.Services;
using Microsoft.AspNetCore.Mvc;
namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {  

        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginRequest loginRequest)
        {
            var user = _userService.Authenticate(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Invalid email or password" });
            }

            var session = _userService.CreateSession(user.Id, user.Role);

            return Ok(new
            {
                UserId = user.Id,
                Email = user.Email,
                Role = user.Role,
                SessionToken = session.SessionToken
            });
        }

        [HttpGet("example")]
        public IActionResult Example()
        {
            var sessionToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var session = _userService.GetSessionByToken(sessionToken);

            if (session == null || session.Role != "admin")
            {
                return Unauthorized();
            }

            return Ok("This is an example information for admin only.");
        }
    }
}
*/
