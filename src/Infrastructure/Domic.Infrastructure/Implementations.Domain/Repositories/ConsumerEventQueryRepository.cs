using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.Entities;
using Domic.Persistence.Models;
using MongoDB.Driver;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.Q;

public class ConsumerEventQueryRepository : IConsumerEventQueryRepository
{
    private readonly IMongoCollection<ConsumerEventQueryModel> _collection;
    
    public ConsumerEventQueryRepository(MongoClient mongoClient) 
        => _collection =
            mongoClient.GetDatabase("StateTrackerService").GetCollection<ConsumerEventQueryModel>("ConsumerEvent");
    
    public ConsumerEventQuery FindById(object id)
    {
        var result = _collection.FindSync(query => query.MessageId == id as string);

        if (result.FirstOrDefault() is null) return null;

        return new();
    }

    public async Task<ConsumerEventQuery> FindByIdAsync(object id, CancellationToken cancellationToken)
    {
        var result =
            await _collection.FindAsync(query => query.MessageId == id as string, cancellationToken: cancellationToken);

        if (result.FirstOrDefault() is null) return null;

        return new();
    }

    public void Add(ConsumerEventQuery entity)
    {
        var newModel = new ConsumerEventQueryModel {
            MessageId = entity.Id,
            Type = entity.Type,
            CountOfRetry = entity.CountOfRetry,
            CreatedAt_EnglishDate = entity.CreatedAt_EnglishDate,
            CreatedAt_PersianDate = entity.CreatedAt_PersianDate
        };
        
        _collection.InsertOne(newModel);
    }
}