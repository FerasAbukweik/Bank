namespace WebApplication6.DTOs.Transactions
{
    public class FilterBankTransactionsDTO
    {
        public long? id { get; set; }
        public long? account_id { get; set; }
        public long? bankTransactionType_id { get; set; }
        public long? bankTransactionStatus_id { get; set; }
    }
}
