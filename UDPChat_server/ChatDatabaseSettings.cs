namespace UDPChat_server;

public class ChatDatabaseSettings : IChatDatabaseSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string MessagesCollectionName { get; set; }
    public string UsersCollectionName { get; set; }
}