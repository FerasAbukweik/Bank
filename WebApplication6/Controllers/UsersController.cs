using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using WebApplication6.DTOs.Users;
using WebApplication6.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private DBcontext _Dbcontext;

        public UsersController(DBcontext dbcontext) { _Dbcontext = dbcontext; }
        [HttpGet("filter")]
        public IActionResult filter([FromQuery]FilterUsersDTO filterData)
        {
            try
            {
                var filteredData = from user in _Dbcontext.users.Where(u =>
                (filterData.id == null || u.id == filterData.id) &&
                (filterData.userName == null || filterData.userName == u.userName) &&
                (filterData.email == null || filterData.email == u.email) &&
                (filterData.phone == null || filterData.phone == u.phone) &&
                (filterData.createdAt == null || filterData.createdAt == u.createdAt))
                                   orderby user.id descending
                                   select new ReturnUserDTO
                                   {
                                       id = user.id,
                                       userName = user.userName,
                                       email = user.email,
                                       phone = user.phone,
                                       createdAt = user.createdAt
                                   };
                return Ok(filteredData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public IActionResult add([FromBody]AddUserDTO toAddData)
        {
            try
            {
                var foundUsers = _Dbcontext.users.FirstOrDefault(u =>
                (u.userName == toAddData.userName) ||
                (u.phone == toAddData.phone) ||
                (u.email == toAddData.email));

                if (foundUsers != null)
                {
                    if (foundUsers.userName == toAddData.userName)
                    {
                        return BadRequest("User Name Already Used");
                    }
                    if (foundUsers.phone == toAddData.phone)
                    {
                        return BadRequest("Phone Number Alreay Used");
                    }
                    if (foundUsers.email == toAddData.email)
                    {
                        return BadRequest("Email Alreay Used");
                    }
                }
                User user = new User
                {
                    userName = toAddData.userName,
                    hashedPassword = BCrypt.Net.BCrypt.HashPassword(toAddData.password),
                    email = toAddData.email,
                    phone = toAddData.phone,
                    createdAt = DateTime.Now,
                };
                _Dbcontext.users.Add(user);
                _Dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("update")]
        public IActionResult update([FromBody]UpdateUserDTO toUpdate)
        {
            try
            {
                var foundUser = _Dbcontext.users.FirstOrDefault(u => u.id == toUpdate.id);
                if (foundUser == null)
                {
                    return BadRequest("User Not Found");
                }
                foundUser.userName = toUpdate.userName ?? foundUser.userName;
                foundUser.email = toUpdate.email ?? foundUser.email;
                foundUser.phone = toUpdate.phone ?? foundUser.phone;

                if (toUpdate.password != null)
                {
                    foundUser.hashedPassword = BCrypt.Net.BCrypt.HashPassword(toUpdate.password);
                }
                _Dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete")]
        public IActionResult delete([FromQuery]long id)
        {
            try
            {
                var foundUser = _Dbcontext.users.FirstOrDefault(u => u.id == id);
                if (foundUser == null)
                {
                    return BadRequest("User Not Found");
                }
                _Dbcontext.users.Remove(foundUser);
                _Dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
