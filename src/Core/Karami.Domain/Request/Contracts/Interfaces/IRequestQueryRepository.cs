using Karami.Core.Domain.Contracts.Interfaces;
using Karami.Domain.Request.Entities;
using MongoDB.Bson;

namespace Karami.Domain.Request.Contracts.Interfaces;

public interface IRequestQueryRepository : IQueryRepository<SystemRequestQuery, ObjectId>
{
    
}