using Domic.Domain.Request.Contracts.Interfaces;
using Domic.Domain.Request.Entities;
using MongoDB.Driver;

namespace Domic.Infrastructure.Implementations.Domain.Repositories;

public class RequestQueryRepository : IRequestQueryRepository
{
    private readonly IMongoCollection<SystemRequestQuery> _collection;
    
    public RequestQueryRepository(MongoClient mongoClient) 
        => _collection = mongoClient.GetDatabase("StateTrackerService").GetCollection<SystemRequestQuery>("Request");
    
    public void Add(SystemRequestQuery entity) => _collection.InsertOne(entity);
}