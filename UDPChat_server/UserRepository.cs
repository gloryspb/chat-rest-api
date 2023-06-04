using MongoDB.Driver;
using UDPChat_server.Models;

namespace UDPChat_server;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _users;

    public UserRepository(IMongoClient client, IChatDatabaseSettings settings)
    {
        var database = client.GetDatabase(settings.DatabaseName);
        _users = database.GetCollection<User>(settings.UsersCollectionName);
    }

    public async Task<User> GetUserById(string id)
    {
        return await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
    }

    public async Task<User> GetUserByUsername(string username)
    {
        return await _users.Find(u => u.Username == username).FirstOrDefaultAsync(); 
    }

    public async Task CreateUser(User user)
    {
        await _users.InsertOneAsync(user);
    }

    public async Task<bool> VerifyPassword(User user, string password)
    {
        // Реализация проверки пароля пользователя
    }
}