using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class BankTransaction
    {
        [Key]
        public long Id { get; set; }
        public DateTime? created_at { get; set; }
        public long amount { get; set; }


        [ForeignKey(nameof(account))]
        public long? account_id { get; set; }
        public Account? account { get; set; }
        [ForeignKey(nameof(transactionInfo__type))] // transaction Types | Major Code Always 2
        public long? transactionInfo_id__type { get; set; }
        public transactionTypes? transactionInfo__type { get; set; }
        [ForeignKey(nameof(transactionInfo__status))] // transaction Status | Major Code Always 1
        public long? transactionInfo_id__status { get; set; }
        public transactionTypes? transactionInfo__status { get; set; }
    }
}
