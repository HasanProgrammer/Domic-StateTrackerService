using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.Entities;
using MongoDB.Driver;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.Q;

public class ConsumerEventQueryRepository : IConsumerEventQueryRepository
{
    private readonly IMongoCollection<ConsumerEventQuery> _collection;
    
    public ConsumerEventQueryRepository(MongoClient mongoClient) 
        => _collection =
            mongoClient.GetDatabase("StateTrackerService").GetCollection<ConsumerEventQuery>("ConsumerEventQuery");
    
    public ConsumerEventQuery FindById(object id)
    {
        var result = _collection.FindSync(query => query.Id == id as string);

        if (result.First() is null) return null;

        return new();
    }

    public async Task<ConsumerEventQuery> FindByIdAsync(object id, CancellationToken cancellationToken)
    {
        var result =
            await _collection.FindAsync(query => query.Id == id as string, cancellationToken: cancellationToken);

        if (result.First() is null) return null;

        return new();
    }

    public void Add(ConsumerEventQuery entity) => _collection.InsertOne(entity);
}