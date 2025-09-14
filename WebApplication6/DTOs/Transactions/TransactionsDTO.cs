using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication6.Models;

namespace WebApplication6.DTOs.Transactions
{
    public class TransactionsDTO
    {
        [Key]
        public long Id { get; set; }
        public DateTime? created_at { get; set; }
        public long amount { get; set; }
        public long? account_id { get; set; }
        public long? transactionType_id { get; set; }
        public long? TransactionStatus_id { get; set; }
    }
}
