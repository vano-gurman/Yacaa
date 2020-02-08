using System.ComponentModel.DataAnnotations;

namespace Yacaa.Shared.Models.Dictionaries
{
    public class Currency
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}