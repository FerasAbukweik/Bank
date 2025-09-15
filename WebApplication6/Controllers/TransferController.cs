using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Transactions;
using WebApplication6.DTOs.Transfers;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private DBcontext _dbcontext;

        private int Role => int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "0");
        private long UserId => int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");

        public TransferController(DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost("add")] //16
        public IActionResult add([FromBody] AddTransferDTO toAdd)
        {
            long tokenId = UserId;

            var fromUser = _dbcontext.accounts.FirstOrDefault(a => a.id == toAdd.fromAccount_id && a.user_id == tokenId);
            var toUser = _dbcontext.accounts.FirstOrDefault(a => a.id == toAdd.toAccount_id && a.user_id == tokenId);

            if (Role != -1 && !((Role & (int)transferRoles.add) == (int)transferRoles.add && (fromUser != null || toUser != null)))
            {
                return BadRequest("User does not have permission for this operation");
            }

            try
            {
                Transfer transfer = new Transfer
                {
                    amount = toAdd.amount,
                    createdAt = DateTime.Now,
                    TransactionType = toAdd.TransactionType,
                    transactionStatus = transactionStatusEnums.Pending,
                    fromAccount_id = toAdd.fromAccount_id,
                    toAccount_id = toAdd.toAccount_id,
                };
                _dbcontext.Add(transfer);
                _dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("filter")] //32
        public IActionResult filter([FromQuery] FilterTransferDTO filterData)
        {
            if (Role != -1 && (Role & (int)transferRoles.filter) != (int)transferRoles.filter)
            {
                return BadRequest("User does not have permission to access this data");
            }

            try
            {
                var foundData = from transfer in _dbcontext.transfers.Where(t =>
                    (filterData.id == null || filterData.id == t.id) &&
                    (filterData.amount == null || filterData.amount == t.amount) &&
                    (filterData.createdAt == null || filterData.createdAt == t.createdAt) &&
                    (filterData.TransactionType == null || filterData.TransactionType == t.TransactionType) &&
                    (filterData.transactionStatus == null || filterData.transactionStatus == t.transactionStatus) &&
                    (filterData.fromAccount_id == null || filterData.fromAccount_id == t.fromAccount_id) &&
                    (filterData.toAccount_id == null || filterData.toAccount_id == t.toAccount_id))
                                select new ReturnTransferDTO
                                {
                                    id = transfer.id,
                                    amount = transfer.amount,
                                    createdAt = transfer.createdAt,
                                    TransactionType = transfer.TransactionType,
                                    transactionStatus = transfer.transactionStatus,
                                    fromAccount_id = transfer.fromAccount_id,
                                    toAccount_id = transfer.toAccount_id,
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
