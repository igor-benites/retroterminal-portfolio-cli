using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AiChatbotAPI.Services
{
    public interface IChatService
    {
        Task<string> ProcessCommandAsync(string command);
    }

    public class ChatService : IChatService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly object _curriculumData;

        public ChatService(HttpClient httpClient, string apiKey, object curriculumData)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
            _curriculumData = curriculumData;
        }

        public async Task<string> ProcessCommandAsync(string command)
        {
            var response = await CallDeepSeekApiAsync(command);
            return response;
        }

        private async Task<string> CallDeepSeekApiAsync(string command)
        {
            // Serialize only the necessary data from _curriculumData
            var curriculumDataSerialized = JsonConvert.SerializeObject(_curriculumData, new JsonSerializerSettings
            {
                // Customize serialization if needed
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore // In case there are circular references
            });

            var systemMessage = new
            {
                role = "system",
                content = curriculumDataSerialized // Use the serialized curriculum data directly
            };

            var userMessage = new
            {
                role = "user",
                content = command
            };

            var requestBody = new
            {
                model = "deepseek-chat",
                messages = new[] { systemMessage, userMessage },
                stream = false
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api.deepseek.com/chat/completions")
            {
                Content = content
            };

            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            try
            {
                var response = await _httpClient.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);

                    var assistantMessage = responseObject?.choices[0]?.message?.content?.ToString();
                    return assistantMessage ?? "Sorry, I couldn't process your request.";
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    return $"Error: {response.StatusCode} - {errorMessage}";
                }
            }
            catch (Exception ex)
            {
                return $"Request failed: {ex.Message}";
            }
        }
    }
}
