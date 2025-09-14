using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication6.Models;

namespace WebApplication6.DTOs.Transfers
{
    public class ReturnTransferDTO
    {
        public int id { get; set; }
        public long? fromBankTransaction_id { get; set; }
        public long? toBankTransaction_id { get; set; }
    }
}
