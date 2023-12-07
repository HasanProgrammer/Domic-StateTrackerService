using Karami.Core.Domain.Entities;
using MongoDB.Bson;

namespace Karami.Core.Domain.Contracts.Interfaces;

public interface IEventQueryRepository : IQueryRepository<EventQuery, ObjectId>
{
    
}