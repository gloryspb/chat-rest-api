namespace UDPChat_server.Models;

public class User
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string PublicKey { get; set; }
}