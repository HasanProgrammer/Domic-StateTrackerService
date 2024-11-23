using MongoDB.Bson;

namespace Domic.Persistence.Models;

public class EventQueryModel
{
    public string EventId  { get; set; } //Name Of Event
    public string Type     { get; set; } //Name Of Event
    public string Service  { get; set; } //Name Of Service
    public string Payload  { get; set; }
    public string Table    { get; set; }
    public string Action   { get; set; } //CREATE | UPDATE | DELETE
    public string RaisedBy { get; set; } //Username
    
    public BsonDateTime CreatedAt_EnglishDate { get; set; }
    public string CreatedAt_PersianDate { get; set; }
}