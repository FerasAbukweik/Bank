using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class Transfer
    {
        [Key]
        public int id { get; set; }


        [ForeignKey(nameof(from_account))]
        public long? from_id { get; set; }
        public Transaction? from_account { get; set; }
        [ForeignKey(nameof(to_account))]
        public long? to_id { get; set; }
        public Transaction? to_account { get; set; }
    }
}
