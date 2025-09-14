using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class transactionStatus
    {
        [Key]
        public long id { get; set; }
        public string status { get; set; }
    }
}
