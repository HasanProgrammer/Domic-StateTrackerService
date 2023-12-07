using Karami.Domain.Request.Contracts.Interfaces;
using Karami.Domain.Request.Entities;
using MongoDB.Driver;

namespace Karami.Infrastructure.Implementations.Domain.Repositories;

public class RequestQueryRepository : IRequestQueryRepository
{
    private readonly IMongoCollection<SystemRequestQuery> _collection;
    
    public RequestQueryRepository(MongoClient mongoClient) 
        => _collection = mongoClient.GetDatabase("StateTrackerService").GetCollection<SystemRequestQuery>("Request");
    
    public void Add(SystemRequestQuery entity) => _collection.InsertOne(entity);
}