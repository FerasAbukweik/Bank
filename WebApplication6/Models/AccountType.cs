using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class AccountType
    {
        [Key]
        public long id { set; get; }
        public string type { get; set; }
    }
}