using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using WebApplication6.DTOs.Users;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private DBcontext _Dbcontext;

        public UsersController(DBcontext dbcontext) { _Dbcontext = dbcontext; }
        [HttpGet(nameof(filter))]
        public IActionResult filter([FromQuery]FilterUsersDTO filterData)
        {
            try
            {
                var filteredData = from user in _Dbcontext.users.Where(u =>
                (filterData.id == null || u.id == filterData.id) &&
                (filterData.user_name == null || filterData.user_name == u.user_name) &&
                (filterData.email == null || filterData.email == u.email) &&
                (filterData.phone == null || filterData.phone == u.phone) &&
                (filterData.created_at == null || filterData.created_at == u.created_at))
                                   orderby user.id descending
                                   select new UserDTO
                                   {
                                       id = user.id,
                                       user_name = user.user_name,
                                       email = user.email,
                                       phone = user.phone,
                                       created_at = user.created_at
                                   };
                return Ok(filteredData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(nameof(add))]
        public IActionResult add([FromBody]SaveUserDTO toAddData)
        {
            try
            {
                var foundUsers = _Dbcontext.users.FirstOrDefault(u =>
                (u.user_name == toAddData.user_name) ||
                (u.phone == toAddData.phone) ||
                (u.email == toAddData.email));

                if (foundUsers != null)
                {
                    if (foundUsers.user_name == toAddData.user_name)
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
                    id = 0,
                    user_name = toAddData.user_name,
                    hashed_password = BCrypt.Net.BCrypt.HashPassword(toAddData.password),
                    email = toAddData.email,
                    phone = toAddData.phone,
                    created_at = DateTime.Now,
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
    }
}
