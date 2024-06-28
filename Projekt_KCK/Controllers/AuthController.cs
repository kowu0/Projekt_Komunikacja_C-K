using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Projekt_KCK.Dtos;
using Projekt_KCK.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Projekt_KCK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {
            if (_context.User.Any(u => u.Username == register.Username))
            {
                return BadRequest("Username already exists.");
            }

            var user = new RegisteredUser
            {
                Username = register.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(register.Password),
                Role = "user" // Default role
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            if (IsValidUser(login, out var role))
            {
                var token = GenerateJwtToken(login.Username, role);
                return Ok(new { token });
            }
            return Unauthorized();
        }


        [HttpGet("users")]
        [Authorize(Policy = "AdminOrUserPolicy")]
        public IActionResult GetAllUsersWithRoleUser()
        {
            var users = _context.User
                .Where(u => u.Role == "user")
                .Select(u => new { u.Id, u.Username, u.Role })
                .ToList();

            return Ok(users);
        }


        private bool IsValidUser(LoginDto login, out string role)
        {
            role = null;
            var user = _context.User.SingleOrDefault(u => u.Username == login.Username);

            if (user != null && BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
            {
                role = user.Role;
                return true;
            }

            return false;
        }

        private string GenerateJwtToken(string username, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourSuperSecretKey1234567890123456"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(ClaimTypes.Role, role) // Ensure role claim is added
        };

            var token = new JwtSecurityToken(
                issuer: "yourIssuer",
                audience: "yourAudience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(3),
                signingCredentials: credentials);

            return "Bearer " + new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}



