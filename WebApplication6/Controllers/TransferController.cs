using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Transactions;
using WebApplication6.DTOs.Transfers;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private DBcontext _dbcontext;

        private int tokenRole => int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "0");
        private long tokenUserId => int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0");

        public TransferController(DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost("add")] //16
        public IActionResult add([FromBody] AddTransferDTO toAdd)
        {
            if (tokenRole != -1 && !((tokenRole & (int)transferRoles.add) == (int)transferRoles.add && (toAdd.fromUserId == tokenUserId)))
            {
                return BadRequest("User does not have permission for this operation");
            }

            try
            {
                var from_Account = _dbcontext.accounts.FirstOrDefault(a => a.id == toAdd.fromAccount_id);
                var to_Account = _dbcontext.accounts.FirstOrDefault(a => a.id == toAdd.toAccount_id);
                if(to_Account == from_Account) {return BadRequest("Cannt Send Money To The Same Account");}

                if (toAdd.TransactionType == transactionTypesEnums.Withdrawal)
                {
                    if(from_Account == null) {return BadRequest("fromAccount Doesnt Exist");}
                    from_Account.balance -= toAdd.amount;
                }

                else if(toAdd.TransactionType == transactionTypesEnums.Deposit)
                {
                    if (to_Account == null) { return BadRequest("fromAccount Doesnt Exist"); }
                    to_Account.balance += toAdd.amount;
                }

                else if (to_Account == null) {return BadRequest("to Account Doesnt Exist");}
                else if(from_Account == null) {return BadRequest("from Account Doesnt Exist");}
                
                else if(toAdd.TransactionType == transactionTypesEnums.send)
                {
                    from_Account.balance -= toAdd.amount;
                    to_Account.balance += toAdd.amount;
                }
                    Transfer transfer = new Transfer
                    {
                        amount = toAdd.amount,
                        createdAt = DateTime.Now,
                        TransactionType = toAdd.TransactionType,
                        transactionStatus = transactionStatusEnums.Pending,
                        fromAccount_id = toAdd.fromAccount_id,
                        toAccount_id = toAdd.toAccount_id,
                        fromUserId = toAdd.fromUserId,
                        toUserId = toAdd.toUserId
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
            if (tokenRole != -1 &&
                !((tokenRole & (int)transferRoles.filter) == (int)transferRoles.filter && (filterData.fromUserId == tokenUserId || filterData.toUserId == tokenUserId)))
            {
                return BadRequest("User does not have permission for this operation");
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
                                orderby transfer.id descending
                                select new ReturnTransferDTO
                                {
                                    id = transfer.id,
                                    amount = transfer.amount,
                                    createdAt = transfer.createdAt,
                                    TransactionType = transfer.TransactionType,
                                    transactionStatus = transfer.transactionStatus,
                                    fromAccount_id = transfer.fromAccount_id,
                                    toAccount_id = transfer.toAccount_id,
                                    fromUserId = transfer.fromUserId,
                                    toUserId = transfer.toUserId
                                };

                return Ok(foundData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getNumberOfTransfers")]
        public IActionResult getNumberOfTransfers(long userId)
        {
            //if (tokenRole != -1 &&
            //    !((tokenRole & (int)transferRoles.getNumberOfTransfers) == (int)transferRoles.getNumberOfTransfers && (userId == tokenUserId)))
            //{
            //    return BadRequest("User does not have permission for this operation");
            //}
            try
            {
                long numOfTransfers = 0;
                foreach (var transfer in _dbcontext.transfers.Where(t => (t.fromUserId == userId) || (t.toUserId == userId)))
                {
                    numOfTransfers++;
                }
                return Ok(numOfTransfers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getRecentActivity")]
        public IActionResult getRecentActivities(long userId)
        {
            try
            {
                var foundActivities = from account in _dbcontext.accounts.Where(a => a.user_id == userId)
                                      from transfer in _dbcontext.transfers.Where(t => (t.fromAccount_id == account.id) ||
                                      (t.toAccount_id == account.id))
                                      orderby transfer.id
                                      select new returnRecentActivities
                                      {
                                          id = transfer.id,
                                          amount = transfer.amount,
                                          deposit = account.id == transfer.toAccount_id,
                                      };
                return Ok(foundActivities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
