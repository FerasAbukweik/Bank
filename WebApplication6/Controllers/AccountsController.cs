using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.DTOs.Accounts;
using WebApplication6.Models;

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
        [HttpPost(nameof(add))]
        public IActionResult add([FromBody]SaveAccountDTO toAddData)
        {
            try
            {
                Account accoutToAdd = new Account
                {
                    id = 0,
                    user_id = toAddData.user_id,
                    accountInfo_id__type = toAddData.accountInfo_id__type,
                    balance = 0,
                    created_at = DateTime.Now
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
        [HttpGet(nameof(filter))]
        public IActionResult filter([FromQuery]FilterAccountsDTO filterData)
        {
            try
            {
                var filteredData = from account in _Dbcontext.accounts.Where(a =>
                (filterData.id == null || filterData.id == a.id) &&
                (filterData.user_id == null || filterData.user_id == a.user_id) &&
                (filterData.filterUsers == null ||
                (filterData.filterUsers.user_name == null || filterData.filterUsers.user_name == a.user.user_name) &&
                (filterData.filterUsers.email == null || filterData.filterUsers.email == a.user.email) &&
                (filterData.filterUsers.phone == null || filterData.filterUsers.phone == a.user.phone) &&
                (filterData.filterUsers.created_at == null || filterData.filterUsers.created_at == a.user.created_at)) &&
                (filterData.accountInfo_id__type == null || filterData.accountInfo_id__type == a.accountInfo_id__type) &&
                (filterData.balance == null || filterData.balance == a.balance) &&
                (filterData.created_at == null || filterData.created_at == a.created_at))
                                   orderby account.id descending
                                   select new AccountsDTO
                                   {
                                       id = account.id,
                                       user_id = account.user_id ?? 0,
                                       accountInfo_id__type = account.accountInfo_id__type,
                                       balance = account.balance,
                                       created_at = account.created_at,
                                       type = account.accountInfo__type.info
                                   };
                return Ok(filteredData);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
