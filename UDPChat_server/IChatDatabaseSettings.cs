﻿namespace UDPChat_server;

public interface IChatDatabaseSettings
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
    string MessagesCollectionName { get; set; }
    string UsersCollectionName { get; set; }
    
}