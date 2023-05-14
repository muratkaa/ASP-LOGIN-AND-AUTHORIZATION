using AuthAPI.Data;
using AuthAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AuthAPI.Services;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Cryptography;
using System.Security.Claims;
using AuthAPI.Tools;
using AuthAPI.Models.DbEntities;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly MVCDemoDbContext _context;
        private readonly UserService _userService;
    

        public LoginController(MVCDemoDbContext context)
        {
            _context = context;
            _userService = new UserService(_context);
        }
        


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest userCredentials)
        {
            
            var user = _context.Users.FirstOrDefault(u => u.Email == userCredentials.Email && u.PasswordHash == PasswordHash(userCredentials.Password));


            if (user == null)
            { 
                
                return Unauthorized();
            }
            string token = CreateToken(user);

            return Ok(token);

        }

        private string PasswordHash(string password)
        {
            
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
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
    }
}
