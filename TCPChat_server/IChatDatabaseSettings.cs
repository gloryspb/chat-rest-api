namespace TCPChat_server;

public interface IChatDatabaseSettings
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
    string CollectionName { get; set; }
}