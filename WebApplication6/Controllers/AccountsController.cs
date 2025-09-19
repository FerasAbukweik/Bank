using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication6.DTOs.Accounts;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly DBcontext _dbcontext;
        private int role => int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "0");
        private long token_userId => int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");

        public AccountsController(DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost("add")] //1
        public IActionResult add([FromBody] AddAccountDTO toAddData)
        {

            if (role != -1 && !((role & (int)accountRoles.add) == (int)accountRoles.add && token_userId == toAddData.user_id))
            {
                return BadRequest("Unauthorized");
            }

            try
            {
                Account accountToAdd = new Account
                {
                    user_id = toAddData.user_id,
                    accountType_id = toAddData.accountTypes_id,
                    createdAt = DateTime.Now
                };
                _dbcontext.accounts.Add(accountToAdd);
                _dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("filter")] //2
        public IActionResult filter([FromQuery] FilterAccountsDTO filterData)
        {

            if (role != -1 && (role & (int)accountRoles.filter) != (int)accountRoles.filter)
            {
                return BadRequest("Unauthorized");
            }

            try
            {
                var filteredData = from account in _dbcontext.accounts
                                   .Where(a =>
                                       (filterData.id == null || filterData.id == a.id) &&
                                       (filterData.user_id == null || filterData.user_id == a.user_id) &&
                                       (filterData.filterUsers == null ||
                                        ((filterData.filterUsers.userName == null || filterData.filterUsers.userName == a.user.userName) &&
                                         (filterData.filterUsers.email == null || filterData.filterUsers.email == a.user!.email) &&
                                         (filterData.filterUsers.phone == null || filterData.filterUsers.phone == a.user!.phone) &&
                                         (filterData.filterUsers.createdAt == null || filterData.filterUsers.createdAt == a.user!.createdAt))) &&
                                       (filterData.accountTypes_id == null || filterData.accountTypes_id == a.accountType_id) &&
                                       (filterData.balance == null || filterData.balance == a.balance) &&
                                       (filterData.createdAt == null || filterData.createdAt == a.createdAt)
                                   )
                                   orderby account.id descending
                                   select new ReturnAccountsDTO
                                   {
                                       id = account.id,
                                       user_id = account.user_id,
                                       accountTypes_id = account.accountType_id,
                                       balance = account.balance,
                                       createdAt = account.createdAt,
                                       type = account.accountType != null ? account.accountType.type : null
                                   };
                return Ok(filteredData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")] //4
        public IActionResult update([FromBody] UpdateAccountDTO toUpdate)
        {

            if (role != -1 && !((role & (int)accountRoles.update) == (int)accountRoles.update && token_userId == toUpdate.user_id))
            {
                return BadRequest("Unauthorized");
            }

            try
            {
                var foundAccount = _dbcontext.accounts.FirstOrDefault(a => a.id == toUpdate.id);
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

                _dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")] //8
        public IActionResult delete(long accountId)
        {
            var account = _dbcontext.accounts.FirstOrDefault(a => a.id == accountId);
            if(account == null) { return BadRequest("Account Not Found"); }

            if (role != -1 && !((role & (int)accountRoles.delete) == (int)accountRoles.delete && token_userId == account.user_id))
            {
                return BadRequest("Unauthorized");
            }

            try
            {

                _dbcontext.accounts.Remove(account);
                _dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("getDashboardAccounts")]
        public IActionResult getDashboardAccounts(long userId)
        {
            if (role != -1 && !((role & (int)accountRoles.getDashboardAccounts) == (int)accountRoles.getDashboardAccounts && token_userId == userId))
            {
                return BadRequest("Unauthorized");
            }
            try
            {
                var foundAccounts = from account in _dbcontext.accounts.Where(a => a.user_id == userId)
                                    from accountType in _dbcontext.accountTypes.Where(t => t.id == account.accountType_id)
                                    select new returnAccountsMinorData
                                    {
                                        id = account.id,
                                        type = accountType.type,
                                        balance = account.balance
                                    };
                return Ok(foundAccounts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getUserIdFromAccountId")]
        public IActionResult getUserIdFromAccountId(long accountId)
        {
            try
            {
                var foundUser = _dbcontext.accounts.FirstOrDefault(a => a.id == accountId);
                if(foundUser == null) { return BadRequest("Account Not Found"); }
                return Ok(foundUser.user_id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
