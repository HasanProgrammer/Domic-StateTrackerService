using Domic.Domain.Request.Contracts.Interfaces;
using Domic.Domain.Request.Entities;
using Domic.Persistence.Models;
using MongoDB.Driver;

namespace Domic.Infrastructure.Implementations.Domain.Repositories;

public class RequestQueryRepository : IRequestQueryRepository
{
    private readonly IMongoCollection<SystemRequestQueryModel> _collection;
    
    public RequestQueryRepository(MongoClient mongoClient) 
        => _collection = mongoClient.GetDatabase("StateTrackerService").GetCollection<SystemRequestQueryModel>("Request");

    public void Add(SystemRequestQuery entity)
    {
        var newSystemRequestQueryModel = new SystemRequestQueryModel {
            Action = entity.Action,
            Service = entity.Service,
            Payload = entity.Payload,
            Header = entity.Header,
            IpClient = entity.IpClient,
            CreatedAt_EnglishDate = entity.CreatedAt_EnglishDate,
            CreatedAt_PersianDate = entity.CreatedAt_PersianDate
        };
        
        _collection.InsertOne(newSystemRequestQueryModel);
    }
}