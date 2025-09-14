namespace WebApplication6.DTOs.Transactions
{
    public class AddBankTransactionDTO
    {
        public long amount { get; set; }
        public long? account_id { get; set; }
        public long? bankTransactionType_id { get; set; }
        public long? bankTransactionStatus_id { get; set; }
    }
}
