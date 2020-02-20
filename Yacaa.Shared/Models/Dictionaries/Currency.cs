﻿using System.ComponentModel.DataAnnotations;

namespace Yacaa.Shared.Models.Dictionaries
{
    public class Currency
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}