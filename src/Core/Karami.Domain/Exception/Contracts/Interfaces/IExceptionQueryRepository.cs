using Karami.Core.Domain.Contracts.Interfaces;
using Karami.Domain.Exception.Entities;
using MongoDB.Bson;

namespace Karami.Domain.Exception.Contracts.Interfaces;

public interface IExceptionQueryRepository : IQueryRepository<SystemExceptionQuery, ObjectId>
{
    
}