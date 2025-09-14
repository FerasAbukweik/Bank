using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class Transaction
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey(nameof(account))]
        public long amount { get; set; }
        public long? account_id { get; set; }
        public Account? account { get; set; }
        public TransactionType type { get; set; }
        public TransactionStatus status { get; set; }
        public DateTime? created_at { get; set; }

    }
}
