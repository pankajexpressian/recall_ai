using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recall_ai.api.Core;
using recall_ai.api.Data;
using recall_ai.api.Models;
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

        public UserDiaryController(ApplicationDbContext dbContext, TextEmbeddingService embeddingService, PineconeClient pineconeClient)
        {
            _dbContext = dbContext;
            _embeddingService = embeddingService;
            _pineconeClient = pineconeClient;
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


            // Generate embedding for the note
            var embedding = await _embeddingService.GetTextEmbedding(diary.Note);

            // Create metadata to store with the vector
            var metadata = new Dictionary<string, string>
            {
                { "UserId", diary.UserId.ToString() },
                { "DiaryId", diary.DiaryId.ToString() },
                { "Date", diary.InsertedOn.ToString("o") }
            };

            // Index the embedding in Pinecone
            await _pineconeClient.IndexVector(diary.DiaryId.ToString(), embedding, metadata);
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
        public async Task<IActionResult> SearchNotes([FromQuery] string query, string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not authenticated");
            }

            // Generate embedding for the query
            var queryEmbedding = await _embeddingService.GetTextEmbedding(query);

            // Search for similar notes in Pinecone for the current user
           var searchResults = await _pineconeClient.SearchVector(queryEmbedding, userId);

            // Fetch the matching DailyEntries from the database
            var notes = _dbContext.UserDiaries
                .Where(note => searchResults.Contains(note.DiaryId.ToString()) && note.UserId.ToString() == userId)
                .ToList();

            return Ok(notes);
        }

    }
}
