using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class User
    {
        [Key]
        public long id { get; set; }
        public string user_name { get; set; }
        public string hashed_password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime created_at { get; set; }
    }
}
