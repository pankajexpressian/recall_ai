using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using recall_ai.api.Models;
using recall_ai.api.Services;

namespace recall_ai.api.Controllers
{
    [ApiController]
    [Route("api/spotify")]
    public class SpotifyController : ControllerBase
    {
        private readonly SpotifyService _spotifyService;

        private readonly IConfiguration _configuration;

        public SpotifyController(SpotifyService spotifyService, IConfiguration configuration)
        {
            _spotifyService = spotifyService;
            _configuration = configuration;
        }

        [HttpPost("recommendations")]
        public async Task<IActionResult> GetRecommendations([FromBody] RecommendationRequest request)
        {
            // Analyze mood based on note text
            string mood = AnalyzeMood(request.NoteText); // Implement mood analysis logic

            if (string.IsNullOrEmpty(request.Token))
            {
                return Unauthorized("User needs to authorize Spotify access.");
            }

            var recommendations = await _spotifyService.GetRecommendationsAsync(request.Token, mood);

            return Ok(recommendations);
        }

        private string AnalyzeMood(string text)
        {
            // Ensure the input text is lowercase for easier matching
            text = text.ToLower();

            // Analyze the text and return the corresponding mood as a string from the enum
            if (text.Contains("happy") || text.Contains("joy") || text.Contains("excited") || text.Contains("delighted"))
                return Mood.JOY.ToString(); // Map to JOY

            if (text.Contains("calm") || text.Contains("peace") || text.Contains("relaxed") || text.Contains("serene"))
                return Mood.NEUTRAL.ToString(); // Map to NEUTRAL (can be customized further)

            if (text.Contains("anger") || text.Contains("furious") || text.Contains("irritated") || text.Contains("rage"))
                return Mood.ANGER.ToString(); // Map to ANGER

            if (text.Contains("disgust") || text.Contains("repelled") || text.Contains("grossed out"))
                return Mood.DISGUST.ToString(); // Map to DISGUST

            if (text.Contains("fear") || text.Contains("scared") || text.Contains("anxious") || text.Contains("terrified"))
                return Mood.FEAR.ToString(); // Map to FEAR

            if (text.Contains("sad") || text.Contains("down") || text.Contains("gloomy") || text.Contains("depressed"))
                return Mood.SADNESS.ToString(); // Map to SADNESS

            if (text.Contains("surprised") || text.Contains("shocked") || text.Contains("amazed") || text.Contains("astonished"))
                return Mood.SURPRISE.ToString(); // Map to SURPRISE

            // Default to NEUTRAL if no specific mood is detected
            return Mood.NEUTRAL.ToString();
        }


        [HttpGet("login")]
        public IActionResult SpotifyLogin()
        {
            string clientId = _configuration["SpotifyService:ClientId"];
            string redirectUri = _configuration["SpotifyService:RedirectUri"];
            string scope = _configuration["SpotifyService:Scope"];

            string spotifyAuthUrl = $"https://accounts.spotify.com/authorize?client_id={clientId}&response_type=code&redirect_uri={redirectUri}&scope={scope}";
            return Redirect(spotifyAuthUrl);
        }

        [HttpGet("callback")]
        public async Task<IActionResult> SpotifyCallback([FromQuery] string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest("Authorization code not provided.");
            }

            string accessToken = await _spotifyService.ExchangeCodeForToken(code);

            // Store access token securely (e.g., in a database, or session if for one-time use)
            // Here, we'll assume we're storing it in memory (e.g., a static variable or similar).
            HttpContext.Session.SetString("SpotifyAccessToken", accessToken); // Example of using session storage
            return Redirect($"http://localhost:4200?token={accessToken}");
            //return Ok("Authorization successful! You can now get recommendations.");
        }

    }

    // Updated RecommendationRequest model
    public class RecommendationRequest
    {
        public string? Token { get; set; }   // Use nullable string
        public string NoteText { get; set; }
    }


}
