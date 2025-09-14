using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class Account
    {
        [Key]
        public long id { get; set; }
        public long balance { get; set; }
        public DateTime createdAt { get; set; }



        [ForeignKey("user")]
        public long? user_id { get; set; }
        public User? user { get; set; }
        [ForeignKey("accountType")]
        public long? accountType_id { get; set; }
        public AccountType? accountType { get; set; }
    }
}
