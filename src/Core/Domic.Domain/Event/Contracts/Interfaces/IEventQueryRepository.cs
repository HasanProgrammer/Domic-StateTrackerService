using Domic.Core.Domain.Entities;
using MongoDB.Bson;

namespace Domic.Core.Domain.Contracts.Interfaces;

public interface IEventQueryRepository : IQueryRepository<EventQuery, ObjectId>
{
    
}