using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.DTOs.Transfers;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private DBcontext _dbcontext;
        public TransferController(DBcontext dbcontext) { _dbcontext = dbcontext; }
        [HttpPost("add")]
        public IActionResult add([FromBody]AddTransferDTO toAdd)
        {
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

        [HttpGet("get")]
        public IActionResult get([FromQuery] FilterTransferDTO filterData)
        {
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
