using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class Account
    {
        [Key]
        public long id { get; set; }
        public long balance { get; set; }
        public DateTime created_at { get; set; }



        [ForeignKey(nameof(user))]
        public long? user_id { get; set; }
        public User? user { get; set; }
        [ForeignKey(nameof(accountInfo__type))]  // Account Type | Major Code Always 1
        public long? accountInfo_id__type { get; set; }
        public AccountInfo? accountInfo__type { get; set; }
    }
}
