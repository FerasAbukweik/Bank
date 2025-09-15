using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication6.DTOs.Role;
using WebApplication6.DTOs.Users;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private DBcontext _Dbcontext;
        private int Role => int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "0");
        private long UserId => int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");

        public UsersController(DBcontext dbcontext)
        {
            _Dbcontext = dbcontext;
        }

        [Authorize] //256
        [HttpGet("filter")]
        public IActionResult filter([FromQuery] FilterUsersDTO filterData)
        {
            if (Role != -1 && (Role & 256) != 256)
            {
                return BadRequest("User does not have permission to filter users");
            }

            try
            {
                var filteredData = from user in _Dbcontext.users.Where(u =>
                    (filterData.id == null || u.id == filterData.id) &&
                    (filterData.userName == null || filterData.userName == u.userName) &&
                    (filterData.email == null || filterData.email == u.email) &&
                    (filterData.phone == null || filterData.phone == u.phone) &&
                    (filterData.createdAt == null || filterData.createdAt == u.createdAt) &&
                    (
                        filterData.filterBankRole == null ||
                        (
                            (filterData.filterBankRole.id == null || filterData.filterBankRole.id == u.BankRole_id) &&
                            (filterData.filterBankRole.role == null || filterData.filterBankRole.role == u.bankRole.role) &&
                            (filterData.filterBankRole.roleName == null || filterData.filterBankRole.roleName == u.bankRole.roleName)
                        )
                    )
                )
                                   orderby user.id descending
                                   select new ReturnUserDTO
                                   {
                                       id = user.id,
                                       userName = user.userName,
                                       email = user.email,
                                       phone = user.phone,
                                       createdAt = user.createdAt,
                                       bankRole_id = user.BankRole_id,
                                       role = user.bankRole.role,
                                       roleName = user.bankRole.roleName
                                   };

                return Ok(filteredData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public IActionResult add([FromBody] AddUserDTO toAddData)
        {
            try
            {
                var foundUsers = _Dbcontext.users.FirstOrDefault(u =>
                    u.userName == toAddData.userName ||
                    u.phone == toAddData.phone ||
                    u.email == toAddData.email
                );

                if (foundUsers != null)
                {
                    if (foundUsers.userName == toAddData.userName) return BadRequest("User Name Already Used");
                    if (foundUsers.phone == toAddData.phone) return BadRequest("Phone Number Already Used");
                    if (foundUsers.email == toAddData.email) return BadRequest("Email Already Used");
                }

                User user = new User
                {
                    userName = toAddData.userName,
                    hashedPassword = BCrypt.Net.BCrypt.HashPassword(toAddData.password),
                    email = toAddData.email,
                    phone = toAddData.phone,
                    createdAt = DateTime.Now,
                    BankRole_id = toAddData.BankRole_id ?? (_Dbcontext.bankRoles.FirstOrDefault(r => r.roleName == nameof(BankRoleEnums.Customer))?.id ?? 1)
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

        [Authorize] //512
        [HttpPut("update")]
        public IActionResult update([FromBody] UpdateUserDTO toUpdate)
        {
            if (Role != -1 && !((Role & 512) == 512 && UserId == toUpdate.id))
            {
                return BadRequest("User does not have permission to update this user");
            }

            try
            {
                var foundUser = _Dbcontext.users.FirstOrDefault(u => u.id == toUpdate.id);
                if (foundUser == null) return BadRequest("User Not Found");

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

        [Authorize(Roles = "-1")]
        [HttpPut("updateRole")]
        public IActionResult updateRole([FromBody] UpdateUserRoleDTO toUpdate)
        {
            try
            {
                User? user = _Dbcontext.users.FirstOrDefault(u => u.id == toUpdate.id);

                if (user == null)
                {
                    return BadRequest("User Not Found");
                }

                user.BankRole_id = toUpdate.bankRole_Id;
                _Dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize] //1024
        [HttpDelete("delete")]
        public IActionResult delete([FromQuery] long id)
        {
            if (Role != -1 && !((Role & 1024) == 1024 && UserId == id))
            {
                return BadRequest("User does not have permission to delete this user");
            }

            try
            {
                var foundUser = _Dbcontext.users.FirstOrDefault(u => u.id == id);
                if (foundUser == null) return BadRequest("User Not Found");

                _Dbcontext.users.Remove(foundUser);
                _Dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
