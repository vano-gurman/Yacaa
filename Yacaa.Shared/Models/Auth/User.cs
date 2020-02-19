namespace Yacaa.Shared.Models.Auth
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordKey { get; set; }
        public Role Role { get; set; }
    }
}