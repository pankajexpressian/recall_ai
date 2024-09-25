using System.ComponentModel.DataAnnotations;

namespace recall_ai.mvc_app.Models
{
    public class SignInSignUpModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string SignUpEmail { get; set; }

        [Required]
        [EmailAddress]
        public string SignInEmail { get; set; }
    }
}
