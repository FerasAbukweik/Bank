using System.ComponentModel.DataAnnotations;

namespace WebApplication6.DTOs.Users
{
    public class FilterUsersDTO
    {
        public long? id { get; set; }
        public string? user_name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public DateTime? created_at { get; set; }
    }
}
