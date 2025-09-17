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
        public IActionResult Add([FromBody] AddTransferDTO toAdd)
        {

            //if (tokenRole != -1 && !((tokenRole & (int)transferRoles.add) == (int)transferRoles.add && (toAdd.fromUserId == tokenUserId))) 
            //{ 
            // return BadRequest("User does not have permission for this operation"); 
            //}

            try
            {
                if(toAdd.toAccount_id != null && toAdd.toUserId == null || toAdd.toAccount_id == null && toAdd.toUserId != null ||
                    toAdd.fromAccount_id != null && toAdd.fromUserId == null || toAdd.fromAccount_id == null && toAdd.fromUserId != null)
                {
                    return BadRequest("Missing Id Or No Account With That Id");
                }

                var from_Account = toAdd.fromAccount_id.HasValue
                    ? _dbcontext.accounts.FirstOrDefault(a => a.id == toAdd.fromAccount_id)
                    : null;

                var to_Account = toAdd.toAccount_id.HasValue
                    ? _dbcontext.accounts.FirstOrDefault(a => a.id == toAdd.toAccount_id)
                    : null;

                if(from_Account!=null && from_Account.user_id != toAdd.fromUserId ||
                    to_Account != null && to_Account.user_id != toAdd.toUserId)
                {
                    return BadRequest("user_Id Account_Id Don't Match");
                }


                if (toAdd.TransactionType == transactionTypesEnums.Withdrawal)
                {
                    if (from_Account == null) return BadRequest("from Account does not exist");
                    if (from_Account.balance < toAdd.amount) return BadRequest("Not enough balance");
                    from_Account.balance -= toAdd.amount;
                }
                else if (toAdd.TransactionType == transactionTypesEnums.Deposit)
                {
                    if (to_Account == null) return BadRequest("to Account does not exist");
                    to_Account.balance += toAdd.amount;
                }
                else if (toAdd.TransactionType == transactionTypesEnums.Send)
                {
                    if (from_Account == null || to_Account == null)
                        return BadRequest("Accounts do not exist");
                    if (from_Account.balance < toAdd.amount)
                        return BadRequest("Not enough balance");
                    from_Account.balance -= toAdd.amount;
                    to_Account.balance += toAdd.amount;
                }
                else
                {
                    return BadRequest("Invalid transaction type");
                }

                var transfer = new Transfer
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
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }


        [HttpGet("filter")] //32
        public IActionResult filter([FromQuery] FilterTransferDTO filterData)
        {
            //if (tokenRole != -1 &&
            //    !((tokenRole & (int)transferRoles.filter) == (int)transferRoles.filter && (filterData.fromUserId == tokenUserId || filterData.toUserId == tokenUserId)))
            //{
            //    return BadRequest("User does not have permission for this operation");
            //}

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
                                      orderby transfer.id descending
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
