using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recall_ai.api.Data;
using recall_ai.api.Models; // Ensure this namespace includes your User model
using System.Linq;
using System.Threading.Tasks;

namespace recall_ai.api.Controllers
{
    [ApiController]
    [Route("api/users")] // Set a base route for users
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get all users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return Ok(users);
        }

        // Get a specific user by ID
        [HttpGet("{userid}", Name = "GetUserById")]
        public async Task<ActionResult<User>> GetUserById(int userid)
        {
            var user = await _dbContext.Users.FindAsync(userid);
            if (user == null) return NotFound();

            return Ok(user);
        }

        // Create a new user
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (user == null || !ModelState.IsValid)
                return BadRequest("Invalid request");

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return CreatedAtRoute("GetUserById", new { userid = user.UserId }, user);
        }

        // Update an existing user
        [HttpPut("{userid}")]
        public async Task<IActionResult> UpdateUser(int userid, [FromBody] User user)
        {
            if (user == null || user.UserId != userid || !ModelState.IsValid)
                return BadRequest("Invalid request");

            var existingUser = await _dbContext.Users.FindAsync(userid);
            if (existingUser == null) return NotFound();

            // Update properties as necessary
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email; 
            // Add more properties as needed

            await _dbContext.SaveChangesAsync();
            return NoContent(); 
        }

        // Delete a user
        [HttpDelete("{userid}")]
        public async Task<IActionResult> DeleteUser(int userid)
        {
            var user = await _dbContext.Users.FindAsync(userid);
            if (user == null) return NotFound();

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return NoContent(); // Indicates that the deletion was successful
        }
    }
}
