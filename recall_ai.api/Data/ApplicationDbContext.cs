using Microsoft.EntityFrameworkCore;
using recall_ai.api.Models;

namespace recall_ai.api.Data
{
   
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDiary> UserDiaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new User { UserId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" },
                new User { UserId = 3, FirstName = "Bob", LastName = "Johnson", Email = "bob.johnson@example.com" },
                new User { UserId = 4, FirstName = "Alice", LastName = "Brown", Email = "alice.brown@example.com" },
                new User { UserId = 5, FirstName = "Charlie", LastName = "Davis", Email = "charlie.davis@example.com" },
                new User { UserId = 6, FirstName = "Emily", LastName = "Miller", Email = "emily.miller@example.com" },
                new User { UserId = 7, FirstName = "Frank", LastName = "Wilson", Email = "frank.wilson@example.com" },
                new User { UserId = 8, FirstName = "Grace", LastName = "Moore", Email = "grace.moore@example.com" },
                new User { UserId = 9, FirstName = "Henry", LastName = "Taylor", Email = "henry.taylor@example.com" },
                new User { UserId = 10, FirstName = "Isabella", LastName = "Anderson", Email = "isabella.anderson@example.com" }
            );

            // Seed UserDiaries
            modelBuilder.Entity<UserDiary>().HasData(
                new UserDiary { DiaryId = 1, UserId = 1, Note = "Feeling great today!", InsertedOn = DateTime.Now, Mood=Mood.Happy, NoteDate=DateTime.Now},
                new UserDiary { DiaryId = 11, UserId = 1, Note = "Feeling great today!", InsertedOn = DateTime.Now, Mood = Mood.Sad, NoteDate = DateTime.Now },
                new UserDiary { DiaryId = 12, UserId = 1, Note = "Feeling great today!", InsertedOn = DateTime.Now, Mood = Mood.Neutral, NoteDate = DateTime.Now },
                new UserDiary { DiaryId = 2, UserId = 2, Note = "Had a productive day.", InsertedOn = DateTime.Now, Mood = Mood.Happy, NoteDate = DateTime.Now },
                new UserDiary { DiaryId = 13, UserId = 2, Note = "Had a productive day.", InsertedOn = DateTime.Now, Mood = Mood.Happy, NoteDate = DateTime.Now },
                new UserDiary { DiaryId = 14, UserId = 2, Note = "Had a productive day.", InsertedOn = DateTime.Now, Mood = Mood.Sad, NoteDate = DateTime.Now },
                new UserDiary { DiaryId = 3, UserId = 3, Note = "Feeling a bit tired.", InsertedOn = DateTime.Now, Mood = Mood.Happy, NoteDate = DateTime.Now },
                new UserDiary { DiaryId = 4, UserId = 4, Note = "Excited about the upcoming event!", InsertedOn = DateTime.Now, Mood = Mood.Happy, NoteDate = DateTime.Now },
                new UserDiary { DiaryId = 5, UserId = 5, Note = "Feeling stressed about work.", InsertedOn = DateTime.Now, Mood = Mood.Neutral, NoteDate = DateTime.Now },
                new UserDiary { DiaryId = 6, UserId = 6, Note = "Enjoyed a nice walk.", InsertedOn = DateTime.Now, Mood = Mood.Happy, NoteDate = DateTime.Now },
                new UserDiary { DiaryId = 7, UserId = 7, Note = "Feeling anxious.", InsertedOn = DateTime.Now, Mood = Mood.Sad, NoteDate = DateTime.Now },
                new UserDiary { DiaryId = 8, UserId = 8, Note = "Had a fun day out.", InsertedOn = DateTime.Now, Mood = Mood.Happy, NoteDate = DateTime.Now },
                new UserDiary { DiaryId = 9, UserId = 9, Note = "Feeling motivated to start new projects.", InsertedOn = DateTime.Now, Mood = Mood.Happy, NoteDate = DateTime.Now },
                new UserDiary { DiaryId = 10, UserId = 10, Note = "Enjoying some quiet time.", InsertedOn = DateTime.Now, Mood = Mood.Happy, NoteDate = DateTime.Now }
            );
        }

    }
}
