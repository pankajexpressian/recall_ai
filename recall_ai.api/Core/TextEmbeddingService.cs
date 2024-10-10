using Newtonsoft.Json;
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

        public async Task<float[]> GetTextEmbedding(string text)
        {
            // Hugging Face API Key
            string apiKey = _huggingFaceApiKey;

            // The model to use for embeddings
            string model = "sentence-transformers/all-MiniLM-L6-v2";

            var url = $"https://api-inference.huggingface.co/models/{model}";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var requestBody = new { inputs = text };
                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var embeddingResponse = JsonConvert.DeserializeObject<List<List<float>>>(jsonResponse);

                return embeddingResponse[0].ToArray();
            }
        }
    }

}
