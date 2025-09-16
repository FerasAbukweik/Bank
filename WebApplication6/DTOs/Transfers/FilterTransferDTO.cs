namespace WebApplication6.DTOs.Transfers
{
    public class FilterTransferDTO
    {
        public int? id { get; set; }
        public long? amount { get; set; }
        public DateTime? createdAt { get; set; }
        public transactionTypesEnums? TransactionType { get; set; }
        public transactionStatusEnums? transactionStatus { get; set; }
        public long? fromAccount_id { get; set; }
        public long? toAccount_id { get; set; }
        public long? fromUserId { get; set; }
        public long? toUserId { get; set; }
    }
}
