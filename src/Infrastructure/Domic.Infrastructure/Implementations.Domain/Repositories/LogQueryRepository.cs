using Domic.Domain.Request.Contracts.Interfaces;
using Domic.Domain.Request.Entities;
using Domic.Persistence.Models;
using MongoDB.Driver;

namespace Domic.Infrastructure.Implementations.Domain.Repositories;

public class LogQueryRepository : ILogQueryRepository
{
    private readonly IMongoCollection<LogQueryModel> _collection;
    
    public LogQueryRepository(MongoClient mongoClient) 
        => _collection = mongoClient.GetDatabase("StateTrackerService").GetCollection<LogQueryModel>("Log");

    public void Add(LogQuery entity)
    {
        var newLogQueryModel = new LogQueryModel {
            Item = entity.Item,
            ServiceName = entity.ServiceName,
            UniqueKey = entity.UniqueKey
        };
        
        _collection.InsertOne(newLogQueryModel);
    }
}