using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
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
        private int tokenRole => int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "0");
        private long tokenUserId => long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");

        public UsersController(DBcontext dbcontext)
        {
            _Dbcontext = dbcontext;
        }

        [Authorize] //64
        [HttpGet("filter")]
        public IActionResult filter([FromQuery] FilterUsersDTO filterData)
        {
            if (tokenRole != -1 && (tokenRole & (int)usersRoles.filter) != (int)usersRoles.filter)
            {
                return BadRequest("Unauthorized");
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
                                       role = user.bankRole != null ? user.bankRole.role : 0,
                                       roleName = user.bankRole != null ? user.bankRole.roleName : "Missing Role"
                                   };

                return Ok(filteredData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getUserById")]
        public IActionResult getUserById(long userId)
        {
            if (tokenRole != -1 && ((tokenRole & (int)usersRoles.getUserById) != (int)usersRoles.getUserById && tokenUserId == userId))
            {
                return BadRequest("Unauthorized");
            }
            try
            {
                var user = _Dbcontext.users.FirstOrDefault(u => u.id == userId);
                return Ok(user);
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
                    BankRole_id = _Dbcontext.bankRoles.FirstOrDefault(r=>r.roleName == nameof(bankRoleEnums.Client))?.id ?? 1,
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

        [Authorize] //128
        [HttpPut("update")]
        public IActionResult update([FromBody] UpdateUserDTO toUpdate)
        {
            if (tokenRole != -1 && !((tokenRole & (int)usersRoles.update) == (int)usersRoles.update && tokenUserId == toUpdate.id))
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


        [Authorize] //256
        [HttpDelete("delete")]
        public IActionResult delete([FromQuery] long id)
        {
            if (tokenRole != -1 && !((tokenRole & (int)usersRoles.delete) == (int)usersRoles.delete && tokenUserId == id))
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

        [Authorize] //1024
        [HttpGet("getTotalBalance")]
        public IActionResult getTotalBalance(long userId)
        {
            if (tokenRole != -1 && !((tokenRole & (int)usersRoles.getTotalBalance) == (int)usersRoles.getTotalBalance && tokenUserId == userId))
            {
                return BadRequest("Unauthorized");
            }
            try
            {
                long totalSum = 0;
                foreach (var account in _Dbcontext.accounts.Where(a => a.user_id == userId))
                {
                    totalSum += account.balance;
                }
                return Ok(totalSum);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
