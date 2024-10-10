using Newtonsoft.Json;
using System.Text;

namespace recall_ai.api.Core
{
    public class PineconeClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _environment;
        private readonly string _indexName;

        public PineconeClient(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiKey = configuration["Pinecone:ApiKey"]; 
            _environment = configuration["Pinecone:Environment"]; 
            _indexName = configuration["Pinecone:IndexName"];
        }

        private HttpRequestMessage CreateRequest(HttpMethod method, string url, object body = null)
        {
            var request = new HttpRequestMessage(method, url);
            request.Headers.Add("Api-Key", _apiKey);
            if (body != null)
            {
                var jsonContent = JsonConvert.SerializeObject(body);
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            }
            return request;
        }

        // Index a vector into Pinecone
        public async Task IndexVector(string vectorId, List<float> embedding, Dictionary<string, string> metadata)
        {
            // Ensure embedding has the correct dimensions
            if (embedding.Count != 1024) // Adjust based on your embedding model
            {
                throw new ArgumentException("Embedding dimension does not match the index dimension.");
            }
            var url = "https://multilingual-e5-large-anftm49.svc.aped-4627-b74a.pinecone.io/vectors/upsert";
            var body = new
            {
                vectors = new[]
                {
                new
                {
                    id = vectorId,
                    values = embedding,
                    metadata
                }
            }
            };

            var request = CreateRequest(HttpMethod.Post, url, body);
            // Debug: Log the request body
            Console.WriteLine("Request Body: " + JsonConvert.SerializeObject(body));
            var response = await _httpClient.SendAsync(request);

            // Check the response
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {response.StatusCode}, Content: {errorContent}");
                throw new Exception($"Failed to index vector: {response.StatusCode} - {errorContent}");
            }
            response.EnsureSuccessStatusCode();
        }

        // Search for similar vectors
        public async Task<List<string>> SearchVector(List<float> embedding, int userId, int topK = 5)
        {
            var url = "https://multilingual-e5-large-anftm49.svc.aped-4627-b74a.pinecone.io/query";
            var body = new
            {
                vector = embedding,
                topK = topK,
                //filter = new { UserId = userId }  // Filter results by UserId
            };

            var request = CreateRequest(HttpMethod.Post, url, body);
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PineconeSearchResponse>(jsonResponse);
            return result.Matches.Select(match => match.Id).ToList();
        }

        public async Task<float[]> GetTextEmbedding(string text)
        {
            // Hugging Face API Key (replace with your actual key)
            string apiKey = "your-huggingface-api-key";

            // The model you want to use (e.g., a Llama-based model or any other Hugging Face model that generates embeddings)
            string model = "sentence-transformers/all-MiniLM-L6-v2";  // Example of a sentence transformer model

            var url = $"https://api-inference.huggingface.co/models/{model}";

            // Create the HTTP request
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                // Create the request body
                var requestBody = new
                {
                    inputs = text
                };

                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                // Make the POST request to Hugging Face API
                var response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                // Read and parse the response
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var embeddingResponse = JsonConvert.DeserializeObject<List<List<float>>>(jsonResponse);

                // Assuming the response contains a single embedding vector
                return embeddingResponse[0].ToArray();
            }
        }

    }

    public class PineconeSearchResponse
    {
        public List<PineconeMatch> Matches { get; set; }
    }

    public class PineconeMatch
    {
        public string Id { get; set; }
    }

}
