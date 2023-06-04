﻿using MongoDB.Driver;
using UDPChat_server.Models;

namespace UDPChat_server;

public class ChatRepository : IChatRepository
{
    private readonly IMongoCollection<ChatMessage> _chatCollection;

    public ChatRepository(IMongoClient mongoClient, IChatDatabaseSettings databaseSettings)
    {
        var database = mongoClient.GetDatabase(databaseSettings.DatabaseName);
        _chatCollection = database.GetCollection<ChatMessage>(databaseSettings.MessagesCollectionName);
    }

    public async Task<List<ChatMessage>> GetAllMessages()
    {
        return await _chatCollection.Find(_ => true).ToListAsync();
    }

    public async Task AddMessage(ChatMessage message)
    {
        await _chatCollection.InsertOneAsync(message);
    }
}