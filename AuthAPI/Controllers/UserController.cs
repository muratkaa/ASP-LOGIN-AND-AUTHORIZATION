
/*using AuthAPI.Models;
using Microsoft.AspNetCore.Mvc;
using AuthAPI.Services;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        /*[HttpPost("authenticate")]
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
        
        [HttpGet("example"), Authorize(Roles = "admin")]
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.Name, user.Email)
    };

            if (user.Role == "admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "person"));
            }




            var Keyyy = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my top secret key, and ı will never forget this key."));
            var creds = new SigningCredentials(Keyyy, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
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