namespace WebApplication6.DTOs.Accounts
{
    public class UpdateAccountDTO
    {
        public long id { get; set; }
        public long? user_id { get; set; }
        public long? accountTypes_id { get; set; }
    }
}
