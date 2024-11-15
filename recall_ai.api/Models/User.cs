﻿using System.ComponentModel.DataAnnotations;

namespace recall_ai.api.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        
        [Required]
        public string Email { get; set; }
    }
}
