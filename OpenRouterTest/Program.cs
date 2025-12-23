using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

namespace OpenRouterTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string apiKey = "sk-or-v1-2daf5329be3d33e3e097a7136c0f468283fd44af6220b812fa54d92f5"; // Replace with your API key
            string model = "gpt-4o-mini"; // or whichever model you want to test

            // Keep chat history
            var messages = new List<Dictionary<string, string>>();

            Console.WriteLine("Type your message (type 'exit' to quit):");

            while (true)
            {
                Console.Write("\nYou: ");
                string userQuestion = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userQuestion)) continue;

                if (userQuestion.Trim().ToLower() == "exit") break;

                // Add user message to history
                messages.Add(new Dictionary<string, string>
                {
                    { "role", "user" },
                    { "content", userQuestion }
                });

                var response = await AskOpenRouter(apiKey, model, messages);

                // Add model response to history
                messages.Add(new Dictionary<string, string>
                {
                    { "role", "assistant" },
                    { "content", response }
                });

                Console.WriteLine($"\nAssistant: {response}");
            }

            Console.WriteLine("Chat ended.");
        }

        static async Task<string> AskOpenRouter(string apiKey, string model, List<Dictionary<string, string>> messages)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestBody = new
            {
                model = model,
                messages = messages
            };

            string json = JsonSerializer.Serialize(requestBody);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://openrouter.ai/api/v1/chat/completions", content);

            if (!response.IsSuccessStatusCode)
            {
                return $"Error: {response.StatusCode}";
            }

            string responseJson = await response.Content.ReadAsStringAsync();

            using JsonDocument doc = JsonDocument.Parse(responseJson);
            string reply = doc.RootElement
                              .GetProperty("choices")[0]
                              .GetProperty("message")
                              .GetProperty("content")
                              .GetString();

            return reply ?? "";
        }
    }
}
