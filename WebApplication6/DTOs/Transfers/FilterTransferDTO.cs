namespace WebApplication6.DTOs.Transfers
{
    public class FilterTransferDTO
    {
        public int? id { get; set; }
        public long? fromBankTransaction_id { get; set; }
        public long? toBankTransaction_id { get; set; }
    }
}
