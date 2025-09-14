using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class AccountInfo
    {
        [Key]
        public long id { set; get; }
        public int majorCode { get; set; }
        public int minorCode { get; set; }
        public string info { get; set; }
    }
}
