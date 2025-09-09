using Avancerad_Lab1.Data;
using Avancerad_Lab1.DTOs;
using Avancerad_Lab1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Avancerad_Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IConfiguration _configuration;
        
        public AuthController(AppDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var user = await _context.Admins.FirstOrDefaultAsync(u => u.UserName == login.UserName);
            
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }
            
            bool passwordMatch = BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash);
            if (!passwordMatch)
            {
                return Unauthorized("Invalid username or password");
            }
            var token = GenerateToken(user);
            
            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Lax,
                Expires = DateTime.UtcNow.AddMinutes(15)
            });
            
            return Ok(new { message = "Login successful" });
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new { message = "Logout successful" });
        }
        private string GenerateToken(Admin admin)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, $"{admin.UserName}"),
                new Claim(ClaimTypes.Role, $"{admin.Role}")
            });
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(15),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
