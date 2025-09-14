using System.ComponentModel.DataAnnotations.Schema;
using WebApplication6.Models;

namespace WebApplication6.DTOs.Accounts
{
    public class AddAccountDTO
    {
        public long user_id { get; set; }
        public long accountTypes_id { get; set; }
        public DateTime created_at { get; set; }
    }
}
