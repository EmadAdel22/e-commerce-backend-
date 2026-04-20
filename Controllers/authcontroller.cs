using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using e_commerce.Models;
using e_commerce.Data;
using BCrypt.Net;

using e_commerce.helpers;

namespace e_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authcontroller : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly jwtSettings _jwtSettings;


        public authcontroller(AppDbContext context, IOptions<jwtSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisrerDto registeruser)
        {
            if (await _context.Users.AnyAsync(u => u.Email == registeruser.Email))
            {
                return BadRequest("Email already exists");
            }

            var newUser = new User
            {
                Name = registeruser.Name,
                Email = registeruser.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registeruser.Password)
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return Ok(new { message = "User created successfully" });


        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto login)
        {
            var loginuser = await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);
            if (loginuser == null ||
                !BCrypt.Net.BCrypt.Verify(login.Password, loginuser.PasswordHash))
            {
                return Unauthorized(new { message = "email or passord incorrect" });
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.NameIdentifier, loginuser.Id.ToString()),
            new Claim(ClaimTypes.Name, loginuser.Name),
            new Claim(ClaimTypes.Email, loginuser.Email)
        }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = _jwtSettings.Issuer,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                expiration = tokenDescriptor.Expires
            });

        }


    }




}

