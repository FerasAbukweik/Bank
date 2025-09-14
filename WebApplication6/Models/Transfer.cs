using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class Transfer
    {
        [Key]
        public int id { get; set; }


        [ForeignKey("fromBankTransaction")]
        public long? fromBankTransaction_id { get; set; }
        public BankTransaction? fromBankTransaction { get; set; }
        [ForeignKey("toBankTransaction")]
        public long? toBankTransaction_id { get; set; }
        public BankTransaction? toBankTransaction { get; set; }
    }
}
