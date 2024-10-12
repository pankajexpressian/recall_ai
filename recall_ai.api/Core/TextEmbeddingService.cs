using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace recall_ai.api.Core
{
    public class TextEmbeddingService
    {
        private readonly string _huggingFaceApiKey;

        public TextEmbeddingService(IConfiguration configuration)
        {
            // Retrieve the API key from appsettings.json
            _huggingFaceApiKey = configuration["HuggingFace:ApiKey"];
        }

        public async Task<List<List<float>>> GetTextEmbedding(string[] notes)
        {
            using (var client = new HttpClient())
            {
                var url = "http://localhost:5000/get_embedding";

                var requestBody = new
                {
                    sentences = notes
                };

                var jsonRequest = JsonConvert.SerializeObject(requestBody);
                var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, httpContent);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to get embeddings: {response.StatusCode}");
                }

                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var embeddingResponse = JsonConvert.DeserializeObject<EmbeddingResponse>(jsonResponse);

                return embeddingResponse.Embeddings;
            }
        }

        //public async Task<float[]> GetTextEmbedding(string text)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _huggingFaceApiKey);

        //        // Ensure the input text is not null or empty
        //        if (string.IsNullOrWhiteSpace(text))
        //        {
        //            throw new ArgumentException("Input text cannot be null or empty.", nameof(text));
        //        }

        //        var requestBody = new { inputs = text };
        //        // Convert the content to JSON
        //        var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
        //        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        //        HttpResponseMessage response;

        //        try
        //        {
        //            string model = "sentence-transformers/all-MiniLM-L6-v2";

        //            var _modelUrl = $"https://api-inference.huggingface.co/models/sentence-transformers/all-MiniLM-L6-v2";
        //            response = await client.PostAsync(_modelUrl, httpContent);
        //            response.EnsureSuccessStatusCode(); // Throws if not a success code

        //            var jsonResponse = await response.Content.ReadAsStringAsync();
        //            var embeddingResponse = JsonConvert.DeserializeObject<List<List<float>>>(jsonResponse);

        //            return embeddingResponse[0].ToArray(); // Assuming the API returns a list of embeddings
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            Console.WriteLine($"Request error: {ex.Message}");
        //            throw; // Re-throw the exception after logging
        //        }
        //    }
        //}

        //public async Task<float[][]> GetEmbeddingsAsync(string[] sentences)
        //{
        //    var url = "http://localhost:5000/get_embedding";

        //    var requestBody = new
        //    {
        //        sentences = sentences
        //    };

        //    var jsonRequest = JsonConvert.SerializeObject(requestBody);
        //    var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        //    var response = await _httpClient.PostAsync(url, httpContent);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new Exception($"Failed to get embeddings: {response.StatusCode}");
        //    }

        //    var jsonResponse = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<List<float>> (jsonResponse);
        //    return result.Embeddings;
        //}

        public async Task<string> SearchNotesAsync(string query, List<string> diaryEntries)
        {
            var client = new HttpClient();
            var url = "http://localhost:5000/search-notes";  // Make sure this matches your Python API address

            var body = new
            {
                query,
                diary_entries = diaryEntries,
                huggingface_token = _huggingFaceApiKey
            };
            try
            {
                var jsonBody = JsonConvert.SerializeObject(body);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                Console.WriteLine(jsonBody);

                var response = await client.PostAsync(url, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to get response: {response.StatusCode}");
                }
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex) // Catch all other exceptions
            {
                // Log the unexpected exception
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                return $"An unexpected error occurred: {ex.Message}";
            }

        }
    }

    public class EmbeddingResponse
    {
        public List<List<float>> Embeddings { get; set; }
    }
}
