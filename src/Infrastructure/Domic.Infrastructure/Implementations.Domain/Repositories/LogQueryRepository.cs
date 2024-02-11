using Domic.Domain.Request.Contracts.Interfaces;
using Domic.Domain.Request.Entities;
using MongoDB.Driver;

namespace Domic.Infrastructure.Implementations.Domain.Repositories;

public class LogQueryRepository : ILogQueryRepository
{
    private readonly IMongoCollection<LogQuery> _collection;
    
    public LogQueryRepository(MongoClient mongoClient) 
        => _collection = mongoClient.GetDatabase("StateTrackerService").GetCollection<LogQuery>("Log");
    
    public void Add(LogQuery entity) => _collection.InsertOne(entity);
}