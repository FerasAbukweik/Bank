using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class TransactionInfo
    {
        [Key]
        public long id {  get; set; }
        public int majorCode { get; set; }
        public int minorCode { get; set; }
        public string info { get; set; }
    }
}
