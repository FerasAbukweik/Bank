using System.ComponentModel.DataAnnotations.Schema;
using WebApplication6.Models;

namespace WebApplication6.DTOs.Accounts
{
    public class AccountsDTO
    {
        public long id { get; set; }
        public long user_id { get; set; }
        public long accountTypes_id { get; set; }
        public long balance { get; set; }
        public DateTime created_at { get; set; }
        public String type { get; set; }
    }
}
