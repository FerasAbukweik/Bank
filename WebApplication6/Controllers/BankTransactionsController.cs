using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication6.DTOs.Transactions;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private DBcontext _dbcontext;
        private int Role => int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "0");
        private long UserId => int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");

        public TransactionsController(DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost("add")] //16
        public IActionResult add([FromBody] AddBankTransactionDTO toAdd)
        {
            if (Role != -1 && !((Role & (int)transactionRoles.add) == (int)transactionRoles.add && UserId == toAdd.account_id))
            {
                return BadRequest("User does not have permission to add this transaction");
            }

            try
            {
                BankTransaction toAddTransaction = new BankTransaction
                {
                    amount = toAdd.amount,
                    account_id = toAdd.account_id,
                    bankTransactionType_id = toAdd.bankTransactionType_id,
                    bankTransactionStatus_id = toAdd.bankTransactionStatus_id,
                };
                _dbcontext.bankTransactions.Add(toAddTransaction);
                _dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("filter")] //32
        public IActionResult filter([FromQuery] FilterBankTransactionsDTO filterData)
        {
            if (Role != -1 && (Role & (int)transactionRoles.filter) != (int)transactionRoles.filter)
            {
                return BadRequest("User does not have permission to access transactions");
            }

            try
            {
                var foundData = from transaction in _dbcontext.bankTransactions.Where(t =>
                    (filterData.id == null || filterData.id == t.id) &&
                    (filterData.account_id == null || filterData.account_id == t.account_id) &&
                    (filterData.bankTransactionType_id == null || filterData.bankTransactionType_id == t.bankTransactionType_id) &&
                    (filterData.bankTransactionStatus_id == null || filterData.bankTransactionStatus_id == t.bankTransactionStatus_id))
                                select new ReturnBankTransactionsDTO
                                {
                                    id = transaction.id,
                                    createdAt = transaction.createdAt,
                                    amount = transaction.amount,
                                    account_id = transaction.account_id,
                                    bankTransactionType_id = transaction.bankTransactionType_id,
                                    bankTransactionStatus_id = transaction.bankTransactionStatus_id,
                                };
                return Ok(foundData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
