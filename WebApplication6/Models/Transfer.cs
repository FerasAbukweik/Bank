using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class Transfer
    {
        [Key]
        public long id { get; set; }
        public long amount { get; set; }
        public DateTime createdAt { get; set; }
        public transferTypesEnums TransactionType { get; set; }


        [ForeignKey("fromAccount")]
        public long? fromAccount_id { get; set; }
        public Account? fromAccount { get; set; }
        [ForeignKey("toAccount")]
        public long? toAccount_id { get; set; }
        public Account? toAccount { get; set; }
        [ForeignKey("fromUser")]
        public long? fromUserId { get; set; }
        public User? fromUser { get; set; }
        [ForeignKey("toUser")]
        public long? toUserId { get; set; }
        public User? toUser { get; set; }

    }
}
