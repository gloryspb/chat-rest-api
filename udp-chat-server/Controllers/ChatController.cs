using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using udp_chat_server.Models;

namespace udp_chat_server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatRepository _chatRepository;

    public ChatController(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<ChatMessage>>> Get()
    {
        var messages = await _chatRepository.GetAllMessages();
        return messages;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ChatMessage message)
    {
        await _chatRepository.AddMessage(message);
        return Ok();
    }
}