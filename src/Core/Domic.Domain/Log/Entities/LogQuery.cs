using Domic.Core.Domain.Contracts.Abstracts;
using MongoDB.Bson;

namespace Domic.Domain.Request.Entities;

public class LogQuery : BaseEntityQuery<ObjectId>
{
    public string UniqueKey   { get; set; }
    public string ServiceName { get; set; }
    public object Item        { get; set; }
}