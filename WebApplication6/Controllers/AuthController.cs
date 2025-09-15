using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication6.DTOs.Auth;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private DBcontext _dbcontext;
        public AuthController(DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet("login")]
        public IActionResult login([FromQuery]LoginDTO loginData)
        {
            User? user = _dbcontext.users.FirstOrDefault(u => u.userName == loginData.userName);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginData.Password, user.hashedPassword))
            {
                return BadRequest("Wrong Info");
            }
            return Ok(generateJWTToken(user));
        }

        private string generateJWTToken(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.userName));
            claims.Add(new Claim(ClaimTypes.Role, _dbcontext.bankRoles.FirstOrDefault(r=>r.id == (int)BankRoleEnums.customer)?.role ?? "customer"));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mdkfa#&$(*1u8fhq(Q@(hfngoaoa892#*(@hufiai"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                claims: claims,
                signingCredentials: creds,
                expires: DateTime.Now.AddHours(1)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
