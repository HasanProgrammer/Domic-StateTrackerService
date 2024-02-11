using Domic.Domain.Exception.Entities;
using Domic.Core.Domain.Contracts.Interfaces;
using MongoDB.Bson;

namespace Domic.Domain.Exception.Contracts.Interfaces;

public interface IExceptionQueryRepository : IQueryRepository<SystemExceptionQuery, ObjectId>
{
    
}