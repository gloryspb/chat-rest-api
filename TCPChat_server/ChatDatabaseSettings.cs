namespace TCPChat_server;

public class ChatDatabaseSettings : IChatDatabaseSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }
}