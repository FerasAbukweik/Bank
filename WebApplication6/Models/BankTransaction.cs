using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace WebApplication6.Models
{
    public class BankTransaction
    {
        [Key]
        public long id { get; set; }
        public DateTime createdAt { get; set; }
        public long amount { get; set; }


        [ForeignKey("account")]
        public long? account_id { get; set; }
        public Account? account { get; set; }
        [ForeignKey("bankTransactionType")]
        public long? bankTransactionType_id { get; set; }
        public BankTransactionType? bankTransactionType { get; set; }
        [ForeignKey("bankTransactionStatus")]
        public long? bankTransactionStatus_id { get; set; }
        public BankTransactionStatus? bankTransactionStatus { get; set; }
    }
}
