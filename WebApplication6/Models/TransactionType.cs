using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class BankTransactionType
    {
        [Key]
        public long id {  get; set; }
        public string type { get; set; }
    }
}
