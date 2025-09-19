namespace WebApplication6.DTOs.Transfers
{
    public class ReturnTransactions
    {
        public long id { get; set; }
        public long amount { get; set; }
        public DateTime createdAt { get; set; }
        public transferTypesEnums TransactionType { get; set; }
    }
}
