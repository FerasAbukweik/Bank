using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class Transfer
    {
        [Key]
        public int id { get; set; }
        public long amount { get; set; }
        public DateTime createdAt { get; set; }
        public transactionTypesEnums TransactionType { get; set; }
        public transactionStatusEnums transactionStatus { get; set; }


        [ForeignKey("fromAccount")]
        public long? fromAccount_id { get; set; }
        public Account? fromAccount { get; set; }
        [ForeignKey("toAccount")]
        public long? toAccount_id { get; set; }
        public Account? toAccount { get; set; }
    }
}
