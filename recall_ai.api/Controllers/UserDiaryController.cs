using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recall_ai.api.Core;
using recall_ai.api.Data;
using recall_ai.api.Models;
using System.Text.RegularExpressions;
using PineconeClient = recall_ai.api.Core.PineconeClient;

namespace recall_ai.api.Controllers
{
    [ApiController]
    [Route("api/users/{userid}/diaries")]
    public class UserDiaryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly TextEmbeddingService _embeddingService;
        private readonly PineconeClient _pineconeClient;
        private readonly OpenAiService _genAIService;
        public UserDiaryController(ApplicationDbContext dbContext, TextEmbeddingService embeddingService, PineconeClient pineconeClient, OpenAiService genAIService)
        {
            _dbContext = dbContext;
            _embeddingService = embeddingService;
            _pineconeClient = pineconeClient;
            _genAIService = genAIService;
        }

        // Get all diaries for a specific user
        [HttpGet]
        public async Task<IActionResult> GetUserDiaries(int userid)
        {
            var diaries = await _dbContext.UserDiaries.Where(a => a.UserId == userid).ToListAsync();
            return Ok(diaries);
        }

        // Get a specific diary by user ID and diary ID
        [HttpGet("{diaryid}")]
        public IActionResult GetDiaryById(int userid, int diaryid)
        {
            var diary = _dbContext.UserDiaries.FirstOrDefault(a => a.UserId == userid && a.DiaryId == diaryid);
            if (diary == null) return NotFound();
            return Ok(diary);
        }

        // Create a new diary
        [HttpPost]
        public async Task<IActionResult> CreateDiary(int userid, [FromBody] UserDiary diary)
        {
            if (diary == null || !ModelState.IsValid)
                return BadRequest("Invalid request");

            diary.UserId = userid; // Set the UserId for the new diary
            await _dbContext.UserDiaries.AddAsync(diary);
            await _dbContext.SaveChangesAsync();

            var sentences = new[] { diary.Note };

            // Generate embedding for the note
            List<List<float>> embeddings = await _embeddingService.GetTextEmbedding(sentences);

            // Since GetTextEmbedding returns a List<List<float>>, you need to get the first embedding if it's a single note
            if (embeddings != null && embeddings.Count > 0)
            {

                var metadata = new Dictionary<string, object>
        {
            { "userId", diary.UserId },
            { "noteDate", diary.NoteDate.ToString("yyyy-MM-dd") },  // Store as string if comparing later as string
            { "mood", diary.Mood.ToString() }
        };
                // Index the embedding in Pinecone; assuming you want to index the first embedding
                await _pineconeClient.IndexVector(diary.DiaryId.ToString(), embeddings[0], metadata);
            }
            return CreatedAtAction(nameof(GetDiaryById), new { userid, diaryid = diary.DiaryId }, diary);
        }

        // Update an existing diary
        [HttpPut("{diaryid}")]
        public async Task<IActionResult> UpdateDiary(int userid, int diaryid, [FromBody] UserDiary diary)
        {
            if (diary == null || diary.DiaryId != diaryid || !ModelState.IsValid)
                return BadRequest("Invalid request");

            var existingDiary = await _dbContext.UserDiaries.FindAsync(diaryid);
            if (existingDiary == null || existingDiary.UserId != userid)
                return NotFound();

            existingDiary.Note = diary.Note;

            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        // Delete a diary
        [HttpDelete("{diaryid}")]
        public async Task<IActionResult> DeleteDiary(int userid, int diaryid)
        {
            var diary = await _dbContext.UserDiaries.FindAsync(diaryid);
            if (diary == null || diary.UserId != userid)
                return NotFound();

            _dbContext.UserDiaries.Remove(diary);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("search-notes")]
        public async Task<IActionResult> SearchNotes([FromQuery] string query, int userid)
        {
            // Validate the user ID
            if (userid <= 0)
            {
                return Unauthorized("User is not authenticated");
            }

            // Extract mood and date from the query
            (Mood? mood, DateTime? date) = ExtractMoodAndDate(query);

            // Assuming mood is of type Mood? (nullable Mood)
            //var results = await _dbContext.UserDiaries
            //    .Where(d => d.UserId == userid &&
            //                (!date.HasValue || d.NoteDate.Date == date.Value.Date) &&
            //                d.Mood == mood) // Compare directly with enum
            //    .ToListAsync();

            //if (!results.Any())
            //{
            //    return NotFound("No notes found matching your query.");
            //}

            // Generate embedding for the query
            var sentences = new[] { query };
            var queryEmbedding = await _embeddingService.GetTextEmbedding(sentences);

            // Search for similar notes in Pinecone for the current user
            var searchResults = await _pineconeClient.SearchVector(queryEmbedding[0], userid);

            // Fetch the matching diary entries from the database based on the search results
            var notes = await _dbContext.UserDiaries
                .Where(note => searchResults.Contains(note.DiaryId.ToString()) && note.UserId == userid)
                .Select(n => new { n.Note, n.NoteDate, n.Mood })
                .ToListAsync();
            var rephraseContext = new List<string>();
            foreach (var note in notes)
            {
                // Generate mood description
                string moodDescription = note.Mood != Mood.None ? note.Mood.ToString() : "no specific mood";

                // Add two entries for each note to rephrase context
                rephraseContext.Add($"On {note.NoteDate.ToShortDateString()}, you felt {moodDescription}.");
                rephraseContext.Add($"You wrote: '{note.Note}'");
            }

            // Check if rephraseContext has entries before proceeding
            if (!rephraseContext.Any())
            {
                    // If no notes are found, create a friendly conversation starter
                    rephraseContext.Add("It seems you haven't written any notes yet. How have you been feeling lately?");
                    rephraseContext.Add("Feel free to share something, and we can talk about it.");
            }

            // Call the Gen-AI model to rephrase the notes in a human-friendly way
            var rephrasedNotes = await _embeddingService.SearchNotesAsync(query, rephraseContext);

            return Ok(new { OriginalNotes = notes, RephrasedNotes = rephrasedNotes });
        }

        private (Mood? mood, DateTime? date) ExtractMoodAndDate(string query)
        {
            // Extract mood using a predefined set of moods
            Mood? mood = null;
            foreach (Mood m in Enum.GetValues(typeof(Mood)))
            {
                if (query.Contains(m.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    mood = m;
                    break;
                }
            }

            // Use regex to find a date in the query
            DateTime date;
            Regex dateRegex = new Regex(@"\b(\d{1,2}[-/]\d{1,2}[-/]\d{2,4}|\w+\s\d{1,2},\s\d{4})\b");
            Match match = dateRegex.Match(query);
            if (match.Success && DateTime.TryParse(match.Value, out date))
            {
                return (mood, date);
            }

            return (mood, null); // Return null if no date found
        }


    }
}
