using OpenAI.Chat;
using System.ClientModel;
using System.Net;
namespace recall_ai.api.Core
{
    public class OpenAiService
    {
        private readonly ChatClient _client;
        public OpenAiService(IConfiguration configuration)
        {
            // Fetch the OpenAI API key from configuration
            var apiKey = configuration["OpenAI:ApiKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("API key for OpenAI is missing from configuration");
            }

            // Initialize OpenAIClient using the provided API key
            _client = new ChatClient(model: "gpt-3.5-turbo", apiKey: apiKey);
        }

        // Example method to generate text completion using Chat API
        public async Task<string> GenerateTextAsync(string note)
        {
            // Send the note to the GPT model for rephrasing
            var prompt = $"Please rephrase the following notes in simple term so that user can feel good and like he is talking to human: \"{note}\"";
            try
            {
                // Send the prompt to the GPT-3.5-turbo model
                ChatCompletion completion = await _client.CompleteChatAsync(prompt);

                // Return the rephrased note
                return completion.Content[0].Text.Trim();
            }
            catch (ClientResultException ex) // Handle specific OpenAI exceptions
            {
                // You can log the exception message if needed
                Console.WriteLine($"Error: {ex.Message}");

                // Check for specific error types based on OpenAI API
                if (ex.Message.Contains("insufficient_quota"))
                {
                    return "Quota exceeded. Please try again later.";
                }
                else if (ex.Message.Contains("Too Many Requests"))
                {
                    return "Request limit exceeded. Please try again later.";
                }
                else if (ex.Message.Contains("Bad Request"))
                {
                    return "There was an error processing your request.";
                }
                else
                {
                    return $"An unexpected error occurred: {ex.Message}";
                }
            }
            catch (Exception ex) // Catch all other exceptions
            {
                // Log the unexpected exception
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                return $"An unexpected error occurred: {ex.Message}";
            }
        }
    }
}
