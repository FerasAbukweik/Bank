using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication6.DTOs.Auth;
using WebApplication6.DTOs.Users;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DBcontext _dbcontext;

        public AuthController(DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet("login")]
        public IActionResult login([FromQuery] LoginDTO loginData)
        {
            User? user = _dbcontext.users.Include(i=>i.bankRole).FirstOrDefault(u => u.userName == loginData.userName);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginData.Password, user.hashedPassword))
            {
                return BadRequest("Wrong Input");
            }

            return Ok(new RetToken{ token = generateJWTToken(user) , roleName = user.bankRole?.roleName ?? "no Role Name Found" , userId = user.id});

        }

        private string generateJWTToken(User user)
        {
            int userRole = _dbcontext.bankRoles.FirstOrDefault(r => r.id == user.BankRole_id)?.role ?? 0;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                new Claim(ClaimTypes.Name, user.userName),
                new Claim(ClaimTypes.Role, userRole.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mdkfa#&$(*1u8fhq(Q@(hfngoaoa892#*(@hufiai"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: creds,
                expires: DateTime.Now.AddHours(1)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
