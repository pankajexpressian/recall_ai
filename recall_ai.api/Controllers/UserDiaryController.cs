using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recall_ai.api.Data;
using recall_ai.api.Models; // Assuming your models are in this namespace
using System.Linq;
using System.Threading.Tasks;

namespace recall_ai.api.Controllers
{
    [ApiController]
    [Route("api/users/{userid}/diaries")] // Set a base route for diaries
    public class UserDiaryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UserDiaryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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

            return NoContent(); // Indicates that the deletion was successful
        }
    }
}
