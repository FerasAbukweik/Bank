using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.DTOs.Accounts;
using WebApplication6.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private DBcontext _Dbcontext;
            public AccountsController(DBcontext dbcontext)
            {
            _Dbcontext = dbcontext;
            }
        [HttpPost("add")]
        public IActionResult add([FromBody]AddAccountDTO toAddData)
        {
            try
            {
                Account accoutToAdd = new Account
                {
                    user_id = toAddData.user_id,
                    accountType_id = toAddData.accountTypes_id,
                    createdAt = DateTime.Now
                };
                _Dbcontext.accounts.Add(accoutToAdd);
                _Dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("filter")]
        public IActionResult filter([FromQuery]FilterAccountsDTO filterData)
        {
            try
            {
                var filteredData = from account in _Dbcontext.accounts.Where(a =>
                (filterData.id == null || filterData.id == a.id) &&
                (filterData.user_id == null || filterData.user_id == a.user_id) &&
                (filterData.filterUsers == null ||
                (filterData.filterUsers.userName == null || filterData.filterUsers.userName == a.user.userName) &&
                (filterData.filterUsers.email == null || filterData.filterUsers.email == a.user.email) &&
                (filterData.filterUsers.phone == null || filterData.filterUsers.phone == a.user.phone) &&
                (filterData.filterUsers.createdAt == null || filterData.filterUsers.createdAt == a.user.createdAt)) &&
                (filterData.accountTypes_id == null || filterData.accountTypes_id == a.accountType_id) &&
                (filterData.balance == null || filterData.balance == a.balance) &&
                (filterData.createdAt == null || filterData.createdAt == a.createdAt))
                                   orderby account.id descending
                                   select new ReturnAccountsDTO
                                   {
                                       id = account.id,
                                       user_id = account.user_id ?? 0,
                                       accountTypes_id = account.accountType_id ?? 0,
                                       balance = account.balance,
                                       createdAt = account.createdAt,
                                       type = account.accountType != null ? account.accountType.type : ""
                                   };
                return Ok(filteredData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("update")]
        public IActionResult update(UpdateAccountDTO toUpdate)
        {
            try
            {
                var foundAccount = _Dbcontext.accounts.FirstOrDefault(a => a.id == toUpdate.id);
                if (foundAccount == null)
                {
                    return BadRequest("Account Not Found");
                }
                if (toUpdate.user_id != 0 && toUpdate.user_id != null)
                {
                    foundAccount.user_id = toUpdate.user_id;
                }
                if (toUpdate.accountTypes_id != 0 && toUpdate.accountTypes_id != null)
                {
                    foundAccount.accountType_id = toUpdate.accountTypes_id;
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
        public IActionResult delete(long id)
        {
            try
            {
                var foundAccount = _Dbcontext.accounts.FirstOrDefault(a => a.id == id);
                if (foundAccount == null)
                {
                    return BadRequest("Account Not Found");
                }
                _Dbcontext.accounts.Remove(foundAccount);
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
