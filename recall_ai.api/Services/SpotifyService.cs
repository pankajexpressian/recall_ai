using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace recall_ai.api.Services
{
    public class SpotifyService
    {
        private readonly string _clientId = "d6a9e0a88e0a4237a4d16f59b297f4a7";
        private readonly string _clientSecret = "960d94591f614a9781c34a4bdaeae1b5";
        private readonly string _redirectUri = "http://localhost:5076/api/spotify/callback";

        public async Task<string> GetAccessTokenAsync(string code)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
                request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"grant_type", "authorization_code"},
                {"code", code},
                {"redirect_uri", _redirectUri},
                {"client_id", _clientId},
                {"client_secret", _clientSecret}
            });

                var response = await client.SendAsync(request);
                var json = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(json);
                return data.access_token;
            }
        }
        public async Task<List<SpotifyTrack>> GetRecommendationsAsync(string accessToken, string mood)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                string query = "Bollywood";

                // Map mood to Spotify audio features
                var moodParams = new Dictionary<string, string>
{
    { "happy", "target_valence=0.8&target_energy=0.8" },
    { "calm", "target_acousticness=0.7&target_valence=0.5" },
    { "angry", "target_valence=0.2&target_energy=0.9" },
    { "sad", "target_valence=0.3&target_acousticness=0.8" },
    { "fearful", "target_energy=0.2&target_acousticness=0.6" },
    { "surprised", "target_valence=0.6&target_energy=0.7" }
};
                var parameters = moodParams.ContainsKey(mood) ? moodParams[mood] : "target_valence=0.5";
                //var url = $"https://api.spotify.com/v1/recommendations?seed_genres=chill&{parameters}&limit=100";
                // Define mood parameter for recommendations (example mood parameter)
                
                // Define artist seeds with popular Bollywood artist IDs
                var seedArtists = "4zCH9qm4R2DADamUHMCa6O,3hwKzo1ysGHiSxkqRY1p6S,1wRPtKGflJrBx9BmLsSwlU"; // Example Bollywood artist IDs

                // Define genres seed
                var seedGenres = "indian,pop";

                // Construct the URL for the recommendations API
                string url = $"https://api.spotify.com/v1/recommendations?seed_genres={seedGenres}&seed_artists={seedArtists}&{parameters}&market=IN&limit=50";

                // Example search query for tracks (if you want to use search as well)
                //string query = "Bollywood hits";
                //string searchUrl = $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(query)}&type=track&market=IN&limit=10";

                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(json);

                // Extract track names, artist names, and preview URLs
                var tracks = new List<SpotifyTrack>();
                foreach (var track in data.tracks)
                {

                    // Check if preview_url is available
                    if (track["preview_url"] != null && !string.IsNullOrEmpty(track["preview_url"].ToString()))
                    {
                        var trackInfo = new SpotifyTrack
                        {
                            Name = track["name"].ToString(),
                            ExternalUrl = track["uri"].ToString(),
                            TrackUri = track["uri"].ToString(),
                            ArtistName = track["artists"][0]["name"].ToString(),
                            ArtistUrl = track["artists"][0]["external_urls"]["spotify"].ToString(),
                            AlbumName = track["album"]["name"].ToString(),
                            AlbumUrl = track["album"]["external_urls"]["spotify"].ToString(),
                            AlbumImageUrl = track["album"]["images"][0]["url"].ToString(),
                            PreviewUrl = track["preview_url"].ToString(),
                        };

                        tracks.Add(trackInfo);
                    }
                }


                return tracks;
            }
        }
        public async Task<string> ExchangeCodeForToken(string code)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
                request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            {"grant_type", "authorization_code"},
            {"code", code},
            {"redirect_uri", "http://localhost:5076/api/spotify/callback"},
            {"client_id", _clientId},
            {"client_secret", _clientSecret}
        });

                var response = await client.SendAsync(request);
                var json = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(json);

                return data.access_token;
            }
        }

    }

    // Define a class to represent track information
    public class SpotifyTrack
    {
        public string Name { get; set; }
        public string ExternalUrl { get; set; }
        public string ArtistName { get; set; }
        public string ArtistUrl { get; set; }
        public string AlbumName { get; set; }
        public string AlbumUrl { get; set; }
        public string AlbumImageUrl { get; set; }
        public string TrackUri { get; set; }
        public string PreviewUrl { get; set; }
    }

}
