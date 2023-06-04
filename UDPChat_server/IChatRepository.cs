using UDPChat_server.Models;

namespace UDPChat_server;

public interface IChatRepository
{
    Task<List<ChatMessage>> GetAllMessages();
    Task AddMessage(ChatMessage message);
}