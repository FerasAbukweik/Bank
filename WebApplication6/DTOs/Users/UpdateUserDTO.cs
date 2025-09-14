namespace WebApplication6.DTOs.Users
{
    public class UpdateUserDTO
    {
        public long id { get; set; }
        public string? userName { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
    }
}
