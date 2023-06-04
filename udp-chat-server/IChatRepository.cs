using udp_chat_server.Models;

namespace udp_chat_server;

public interface IChatRepository
{
    Task<List<ChatMessage>> GetAllMessages();
    Task AddMessage(ChatMessage message);
}