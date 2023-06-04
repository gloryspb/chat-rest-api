using UDPChat_server.Models;

namespace UDPChat_server;

public interface IUserRepository
{
    Task<User> GetUserById(string id);
    Task<User> GetUserByUsername(string username);
    Task CreateUser(User user);
    Task<bool> VerifyPassword(User user, string password);
}