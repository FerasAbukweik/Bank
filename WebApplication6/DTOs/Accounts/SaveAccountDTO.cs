using System.ComponentModel.DataAnnotations.Schema;
using WebApplication6.Models;

namespace WebApplication6.DTOs.Accounts
{
    public class SaveAccountDTO
    {
        public long user_id { get; set; }
        public long accountInfo_id__type { get; set; }
        public DateTime created_at { get; set; }
    }
}
