using System.ComponentModel.DataAnnotations;
using WebApplication6.DTOs.Role;

namespace WebApplication6.DTOs.Users
{
    public class FilterUsersDTO
    {
        public long? id { get; set; }
        public string? userName { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public DateTime? createdAt { get; set; }
        public FilterBankRoleDTO? filterBankRole { get; set; }
    }
}
