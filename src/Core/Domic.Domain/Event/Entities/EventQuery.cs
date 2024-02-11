using Domic.Core.Domain.Contracts.Abstracts;
using MongoDB.Bson;

namespace Domic.Core.Domain.Entities;

public class EventQuery : BaseEntityQuery<ObjectId>
{
    public string Type    { get; set; } //Name Of Event
    public string Service { get; set; } //Name Of Service
    public string Payload { get; set; }
    public string Table   { get; set; }
    public string Action  { get; set; } //CREATE | UPDATE | DELETE
    public string User    { get; set; } //Username
    
    public BsonDateTime CreatedAt_EnglishDate { get; set; }
    public string CreatedAt_PersianDate       { get; set; }
    public BsonDateTime UpdatedAt_EnglishDate { get; set; }
    public string UpdatedAt_PersianDate       { get; set; }
}