using Domic.Domain.Exception.Contracts.Interfaces;
using Domic.Domain.Exception.Entities;
using Domic.Persistence.Models;
using MongoDB.Driver;

namespace Domic.Infrastructure.Implementations.Domain.Repositories;

public class ExceptionQueryRepository : IExceptionQueryRepository
{
    private readonly IMongoCollection<SystemExceptionQueryModel> _collection;
    
    public ExceptionQueryRepository(MongoClient mongoClient) 
        => _collection = mongoClient.GetDatabase("StateTrackerService").GetCollection<SystemExceptionQueryModel>("Exception");

    public void Add(SystemExceptionQuery entity)
    {
        var newSystemExceptionQueryModel = new SystemExceptionQueryModel {
            Exception = entity.Exception,
            Message = entity.Message,
            Action = entity.Action,
            Service = entity.Service,
            CreatedAt_EnglishDate = entity.CreatedAt_EnglishDate,
            CreatedAt_PersianDate = entity.CreatedAt_PersianDate
        };
        
        _collection.InsertOne(newSystemExceptionQueryModel);
    }
}