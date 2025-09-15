using System.ComponentModel.DataAnnotations;

namespace WebApplication6.DTOs.Users
{
    public class ReturnUserDTO
    {
        public long id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime createdAt { get; set; }
        public long? bankRole_id { get; set; }
        public int role { get; set; }
        public string? roleName { get; set; }
    }
}
