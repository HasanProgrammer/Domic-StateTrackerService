using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.Entities;
using Domic.Persistence.Models;
using MongoDB.Driver;

namespace Domic.Infrastructure.Implementations.Domain.Repositories;

public class EventQueryRepository : IEventQueryRepository
{
    private readonly IMongoCollection<EventQueryModel> _collection;

    public EventQueryRepository(MongoClient mongoClient) 
        => _collection = mongoClient.GetDatabase("StateTrackerService").GetCollection<EventQueryModel>("Event");

    public void Add(EventQuery entity)
    {
        var eventQueryModel = new EventQueryModel {
            EventId = entity.Id,
            Type = entity.Type,
            Service = entity.Service,
            Action = entity.Action,
            Payload = entity.Payload,
            Table = entity.Table,
            RaisedBy = entity.User,
            CreatedAt_EnglishDate = entity.CreatedAt_EnglishDate,
            CreatedAt_PersianDate = entity.CreatedAt_PersianDate
        };
        
        _collection.InsertOne(eventQueryModel);
    }
}