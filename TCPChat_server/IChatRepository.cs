using TCPChat_server.Models;

namespace TCPChat_server;

public interface IChatRepository
{
    Task<List<ChatMessage>> GetAllMessages();
    Task AddMessage(ChatMessage message);
}