using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication6.Models;

namespace WebApplication6.DTOs.Transactions
{
    public class ReturnBankTransactionsDTO
    {
        public long id { get; set; }
        public DateTime? created_at { get; set; }
        public long amount { get; set; }
        public long? account_id { get; set; }
        public long? bankTransactionType_id { get; set; }
        public long? bankTransactionStatus_id { get; set; }
    }
}
