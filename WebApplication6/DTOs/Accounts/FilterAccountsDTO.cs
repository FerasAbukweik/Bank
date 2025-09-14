using System.ComponentModel.DataAnnotations.Schema;
using WebApplication6.DTOs.Users;
using WebApplication6.Models;

namespace WebApplication6.DTOs.Accounts
{
    public class FilterAccountsDTO
    {
        public long? id { get; set; }
        public long? user_id { get; set; }
        public FilterUsersDTO? filterUsers { get; set; }
        public long? accountTypes_id { get; set; }
        public long? balance { get; set; }
        public DateTime? createdAt { get; set; }
    }
}
