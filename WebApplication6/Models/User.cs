using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class User
    {
        [Key]
        public long id { get; set; }
        public string userName { get; set; }
        public string hashedPassword { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime createdAt { get; set; }
    }
}
