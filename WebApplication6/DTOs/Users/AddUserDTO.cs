namespace WebApplication6.DTOs.Users
{
    public class AddUserDTO
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public long? BankRole_id { get; set; }
    }
}
