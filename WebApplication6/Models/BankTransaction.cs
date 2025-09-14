using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace WebApplication6.Models
{
    public class BankTransaction
    {
        [Key]
        public long id { get; set; }
        public DateTime? created_at { get; set; }
        public long amount { get; set; }


        [ForeignKey(nameof(account))]
        public long? account_id { get; set; }
        public Account? account { get; set; }
        [ForeignKey(nameof(bankTransactionType))]
        public long? bankTransactionType_id { get; set; }
        public BankTransactionType? bankTransactionType { get; set; }
        [ForeignKey(nameof(bankTransactionStatus))]
        public long? bankTransactionStatus_id { get; set; }
        public BankTransactionStatus? bankTransactionStatus { get; set; }
    }
}
