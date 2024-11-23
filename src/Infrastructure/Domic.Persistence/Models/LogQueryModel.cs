using MongoDB.Bson;

namespace Domic.Persistence.Models;

public class LogQueryModel
{
    public BsonInt64 Id       { get; set; }
    public string UniqueKey   { get; set; }
    public string ServiceName { get; set; }
    public object Item        { get; set; }
}