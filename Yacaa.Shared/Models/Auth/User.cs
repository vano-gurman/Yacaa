using System.ComponentModel.DataAnnotations;

namespace Yacaa.Shared.Models.Auth
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(500)]
        public string PasswordKey { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}