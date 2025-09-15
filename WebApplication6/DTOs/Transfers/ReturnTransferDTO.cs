using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication6.Models;

namespace WebApplication6.DTOs.Transfers
{
    public class ReturnTransferDTO
    {
        public int id { get; set; }
        public long amount { get; set; }
        public DateTime createdAt { get; set; }
        public transactionTypesEnums TransactionType { get; set; }
        public transactionStatusEnums transactionStatus { get; set; }
        public long? fromAccount_id { get; set; }
        public long? toAccount_id { get; set; }
    }
}
