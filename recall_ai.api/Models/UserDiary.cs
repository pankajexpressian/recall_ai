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

        //TODO - Add this to DB, Controller and then in the consumer
        public DateTime NoteDate { get; set; } = DateTime.Now;

        //TODO - Add this to DB, Controller and then in the consumer
        public Mood Mood { get; set; }

        //TODO - Add this to DB, Controller and then in the consumer
        public DateTime InsertedOn { get; set; } = DateTime.Now;
    }

    public enum Mood
    {

        NEUTRAL = 0,
        ANGER = 1,
        DISGUST = 2,
        FEAR = 3,
        JOY = 4,
        SADNESS = 5,
        SURPRISE = 6
    }
}

