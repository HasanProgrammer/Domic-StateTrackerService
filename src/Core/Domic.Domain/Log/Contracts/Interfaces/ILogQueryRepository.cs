using Domic.Domain.Request.Entities;
using Domic.Core.Domain.Contracts.Interfaces;
using MongoDB.Bson;

namespace Domic.Domain.Request.Contracts.Interfaces;

public interface ILogQueryRepository : IQueryRepository<LogQuery, ObjectId>
{
    
}