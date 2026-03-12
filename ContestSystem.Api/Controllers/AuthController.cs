using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContestSystem.Api.Data;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.VisualStudio.Services.UserAccountMapping;
using Microsoft.AspNetCore.Authorization;
using ContestSystem.Api.Models;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto register)
    {
        try
        {
            // 1. Check if user already exists
            if (await _context.Users.AnyAsync(u => u.Username == register.Username))
            {
                return BadRequest(new { message = "Username is already taken." });
            }

            // 2. Create new user with hashed password
            var user = new User
            {
                Username = register.Username,
                Email = register.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(register.Password),
                Role = string.IsNullOrEmpty(register.Role) ? "1" : register.Role // Default to Normal
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Registration failed.", details = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        try
        {
            // Master Admin Check from AppSettings
            var adminSettings = _config.GetSection("AdminUser");
            if (login.Username == adminSettings["Username"] && login.Password == adminSettings["Password"])
            {
                var token = GenerateJWT(login.Username, "3", "1"); // Role 3 = Admin
                return Ok(new { Token = token, Role = "Admin" });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == login.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
                return Unauthorized(new { message = "Invalid credentials" });

            return Ok(new { Token = GenerateJWT(user.Username, user.Role, user.Id.ToString()), Role = user.Role });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal error", details = ex.Message });
        }
    }

    [HttpPost("logout")]
    [Authorize]
    public IActionResult Logout()
    {
        // As discussed, frontend deletes token. Server returns success.
        return Ok(new { message = "Logged out successfully. Token invalidated on client side." });
    }

    private string GenerateJWT(string user, string role, string id)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var claims = new[] {
            new Claim(ClaimTypes.Name, user),
            new Claim(ClaimTypes.Role, role),
            new Claim(ClaimTypes.NameIdentifier, id)
        };
        var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims,
            expires: DateTime.Now.AddHours(2), signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}