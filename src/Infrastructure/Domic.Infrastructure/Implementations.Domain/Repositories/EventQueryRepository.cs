using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.Entities;
using MongoDB.Driver;

namespace Domic.Infrastructure.Implementations.Domain.Repositories;

public class EventQueryRepository : IEventQueryRepository
{
    private readonly IMongoCollection<EventQuery> _collection;

    public EventQueryRepository(MongoClient mongoClient) 
        => _collection = mongoClient.GetDatabase("StateTrackerService").GetCollection<EventQuery>("Event");
    
    public void Add(EventQuery entity) => _collection.InsertOne(entity);
}