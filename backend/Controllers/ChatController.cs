using Microsoft.AspNetCore.Mvc;
using AiChatbotAPI.Services;
using AiChatbotAPI.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace AiChatbotAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;

        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("send-command")]
        public async Task<IActionResult> SendCommand([FromBody] ChatRequest request)
        {
            if (string.IsNullOrEmpty(request.Command))
            {
                return BadRequest("Invalid command");
            }

            try
            {
                var response = await _chatService.ProcessCommandAsync(request.Command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Request failed: {ex.Message}");
            }
        }
    }
}
