using MongoDB.Bson;

namespace Domic.Persistence.Models;

public class ConsumerEventQueryModel
{
    public BsonInt64 Id     { get; set; }
    public string MessageId { get; set; }
    public string Type      { get; set; }
    public int CountOfRetry { get; set; }

    public BsonDateTime CreatedAt_EnglishDate { get; set; }
    public string CreatedAt_PersianDate { get; set; }
}