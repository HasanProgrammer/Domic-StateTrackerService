using MongoDB.Bson;

namespace Domic.Persistence.Models;

public class SystemRequestQueryModel
{
    public string IpClient { get; set; }
    public string Service  { get; set; }
    public string Action   { get; set; }
    public string Header   { get; set; }
    public string Payload  { get; set; }
    
    public BsonDateTime CreatedAt_EnglishDate { get; set; }
    public string CreatedAt_PersianDate { get; set; }
}