using Microsoft.AspNetCore.Mvc;
using recall_ai.api.Data;

namespace recall_ai.api.Controllers
{
    [ApiController]
    public class UserDiaryController : ControllerBase
    {
        private ApplicationDbContext _dbContext { get; set; }
        public UserDiaryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("users/{userid}/diaries")]
        public IActionResult GetUserDiaries(int userid)
        {
            return Ok(_dbContext.UserDiaries.Where(a=>a.UserId==userid).ToList());
        }

        [HttpGet("users/{userid}/diaries/{diaryid}")]
        public IActionResult GetUserById(int userid, int diaryid)
        {
            return Ok(_dbContext.UserDiaries.FirstOrDefault(a => a.UserId == userid && a.DiaryId==diaryid));
        }
        //private readonly ILogger<UserDiaryController> _logger;

        //public UserDiaryController(ILogger<UserDiaryController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpPost]
        //public IActionResult PostDiary([FromBody]Models.UserDiary diary)
        //{
        //    if(!ModelState.IsValid) return BadRequest(ModelState);

        //    return Ok(diary);
        //}


    }
}