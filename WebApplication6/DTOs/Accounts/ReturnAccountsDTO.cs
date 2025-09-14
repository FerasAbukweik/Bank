using System.ComponentModel.DataAnnotations.Schema;
using WebApplication6.Models;

namespace WebApplication6.DTOs.Accounts
{
    public class ReturnAccountsDTO
    {
        public long id { get; set; }
        public long? user_id { get; set; }
        public long? accountTypes_id { get; set; }
        public long balance { get; set; }
        public DateTime createdAt { get; set; }
        public String type { get; set; }
    }
}
