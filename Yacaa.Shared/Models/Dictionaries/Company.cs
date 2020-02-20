using System.ComponentModel.DataAnnotations;

namespace Yacaa.Shared.Models.Dictionaries
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}