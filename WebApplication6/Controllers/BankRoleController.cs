using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.DTOs.Role;
using WebApplication6.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication6.Controllers
{
    [Authorize(Roles = "-1")]
    [Route("api/[controller]")]
    [ApiController]
    public class BankRoleController : ControllerBase
    {
        private DBcontext _dbcontext;
        public BankRoleController(DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [Authorize(Roles = "-1")]
        [HttpGet("GetAll")]
        public IActionResult Getall()
        {
            try
            {
                var allRoles = from role in _dbcontext.bankRoles
                               select new ReturnBankRoleDTO
                               {
                                   id = role.id,
                                   role = role.role,
                                   roleName = role.roleName,
                               };
                return Ok(allRoles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "-1")]
        [HttpPost("Add")]
        public IActionResult add([FromBody]AddRoleDTO toAdd)
        {
            try
            {
                BankRole? foundRole = _dbcontext.bankRoles.FirstOrDefault(r => (r.role == toAdd.role) || r.roleName == toAdd.roleName);
                if (foundRole != null)
                {
                    if (foundRole.role == toAdd.role)
                    {
                        return BadRequest("These permissions are Already avaiable");
                    }
                    if (foundRole.roleName == toAdd.roleName)
                    {
                        return BadRequest("Role Name Is Already Used");
                    }
                }

                BankRole toAddRole = new BankRole
                {
                    role = toAdd.role,
                    roleName = toAdd.roleName,
                };
                _dbcontext.Add(toAddRole);
                _dbcontext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "-1")]
        [HttpPut("update")]
        public IActionResult update([FromBody] UpdateBankRoleDTO toUpdate)
        {
            try
            {
                BankRole? foundRole = _dbcontext.bankRoles.FirstOrDefault(r => r.id == toUpdate.id);
                if (foundRole == null)
                {
                    return BadRequest("Role Not Found");
                }

                foundRole.roleName = toUpdate.roleName ?? foundRole.roleName;
                foundRole.role = toUpdate.role ?? foundRole.role;

                _dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "-1")]
        [HttpDelete("delete")]
        public IActionResult delete(long id)
        {
            try
            {
                BankRole? foundRole = _dbcontext.bankRoles.FirstOrDefault(r => r.id == id);
                if (foundRole == null)
                {
                    return BadRequest("Role Not Found");
                }

                _dbcontext.bankRoles.Remove(foundRole);
                _dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
