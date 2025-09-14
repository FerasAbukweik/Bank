using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class Account
    {
        [Key]
        public long id { get; set; }
        [ForeignKey (nameof(user))]
        public long? user_id { get; set; }
        public User? user  { get; set; }
        public string account_type { get; set; }
        public string balance { get; set; }
        public DateTime created_at { get; set; }

    }
}
