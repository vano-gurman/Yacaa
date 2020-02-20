using System;
using System.ComponentModel.DataAnnotations;
using Yacaa.Shared.Models.Dictionaries;

namespace Yacaa.Shared.Models
{
    public class Contract
    {
        public int Id { get; set; }
        [Required]
        public Company Company { get; set; }
        [Required]
        [MaxLength(50)]
        public string Number { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public ContractType ContractType { get; set; }
        [Required]
        public Currency Currency { get; set; }
        [Required]
        public DateTime ValidUntil { get; set; }
        [Required]
        public bool Prolongation { get; set; }
        [MaxLength(200)]
        public string ProlongationTerms { get; set; } = null;

    }
}