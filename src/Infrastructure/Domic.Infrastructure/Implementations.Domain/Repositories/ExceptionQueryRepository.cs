using Domic.Domain.Exception.Contracts.Interfaces;
using Domic.Domain.Exception.Entities;
using MongoDB.Driver;

namespace Domic.Infrastructure.Implementations.Domain.Repositories;

public class ExceptionQueryRepository : IExceptionQueryRepository
{
    private readonly IMongoCollection<SystemExceptionQuery> _collection;
    
    public ExceptionQueryRepository(MongoClient mongoClient) 
        => _collection = mongoClient.GetDatabase("StateTrackerService").GetCollection<SystemExceptionQuery>("Exception");
    
    public void Add(SystemExceptionQuery entity) => _collection.InsertOne(entity);
}