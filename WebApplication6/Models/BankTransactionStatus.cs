using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class BankTransactionStatus
    {
        [Key]
        public long id { get; set; }
        public string status { get; set; }
    }
}
