using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [HttpPost("add")] //64
        public IActionResult add([FromBody] AddTransferDTO toAdd)
        {
            long tokenId = UserId;

            var fromTransaction = _dbcontext.bankTransactions.FirstOrDefault(t => t.id == toAdd.fromBankTransaction_id);
            var toTransaction = _dbcontext.bankTransactions.FirstOrDefault(t => t.id == toAdd.toBankTransaction_id);

            if (fromTransaction == null || toTransaction == null)
                return BadRequest("Invalid transaction IDs");

            var fromUser = _dbcontext.accounts.FirstOrDefault(a => a.id == fromTransaction.account_id && a.user_id == tokenId);
            var toUser = _dbcontext.accounts.FirstOrDefault(a => a.id == toTransaction.account_id && a.user_id == tokenId);

            if (Role != -1 && !((Role & (int)transferRoles.add) == (int)transferRoles.add && (fromUser != null || toUser != null)))
            {
                return BadRequest("User does not have permission for this operation");
            }

            try
            {
                Transfer transfer = new Transfer
                {
                    fromBankTransaction_id = toAdd.fromBankTransaction_id,
                    toBankTransaction_id = toAdd.toBankTransaction_id,
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

        [HttpGet("filter")] //128
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
                    (filterData.fromBankTransaction_id == null || filterData.fromBankTransaction_id == t.fromBankTransaction_id) &&
                    (filterData.toBankTransaction_id == null || filterData.toBankTransaction_id == t.toBankTransaction_id))
                                select new ReturnTransferDTO
                                {
                                    id = transfer.id,
                                    fromBankTransaction_id = transfer.fromBankTransaction_id,
                                    toBankTransaction_id = transfer.toBankTransaction_id,
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
