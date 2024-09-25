namespace recall_ai.mvc_app.Models
{
    public class UserDiary
    {
        public int DiaryId { get; set; }

        public int UserId { get; set; }

        public string Note { get; set; }

        public DateTime InsertedOn { get; set; } = DateTime.Now;
    }
}
