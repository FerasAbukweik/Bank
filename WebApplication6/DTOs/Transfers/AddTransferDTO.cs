namespace WebApplication6.DTOs.Transfers
{
    public class AddTransferDTO
    {
        public long amount { get; set; }
        public transactionTypesEnums TransactionType { get; set; }
        public long? fromAccount_id { get; set; }
        public long? toAccount_id { get; set; }
        public long? fromUserId { get; set; }
        public long? toUserId { get; set; }
    }
}
