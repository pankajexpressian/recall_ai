using System.ComponentModel.DataAnnotations;

namespace recall_ai.api.Models
{
    public class UserDiary
    {
        [Key]
        public int DiaryId { get; set; }

        [Required]
        public int UserId { get; set; }
        
        [Required]
        [MaxLength(1000, ErrorMessage = "Note cannot have more than 1000 characters.")]
        public string Note { get; set; }
        
        public DateTime InsertedOn { get; set; } = DateTime.Now;
    }
}
