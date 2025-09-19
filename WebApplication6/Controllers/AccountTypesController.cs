using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypesController : ControllerBase
    {
        private DBcontext _dbcontext;
        public AccountTypesController(DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet("getAll")]
        public IActionResult getAll()
        {
            try
            {
                var accountTypes = _dbcontext.accountTypes;
                return Ok(accountTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public IActionResult add([FromQuery] String AccountType)
        {
            try
            {
                AccountType toAdd = new AccountType
                {
                    type = AccountType
                };
                _dbcontext.accountTypes.Add(toAdd);
                _dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public IActionResult delete([FromQuery] long id)
        {
            try
            {
                var accountType = _dbcontext.accountTypes.FirstOrDefault(x => x.id == id);
                if (accountType == null)
                {
                    return NotFound("Account type not found");
                }
                _dbcontext.accountTypes.Remove(accountType);
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
