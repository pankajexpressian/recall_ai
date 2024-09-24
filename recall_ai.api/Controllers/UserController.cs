using Microsoft.AspNetCore.Mvc;
using recall_ai.api.Data;

namespace recall_ai.api.Controllers
{
    [ApiController]
    public class UserController:ControllerBase
    {
        private ApplicationDbContext _dbContext { get; set; }
        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            return Ok(_dbContext.Users.ToList());
        }

        [HttpGet("users/{userid}")]
        public IActionResult GetUserById(int userid)
        {
            return Ok(_dbContext.Users.FirstOrDefault(a=>a.UserId==userid));
        }
    }
}
