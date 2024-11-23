using Domic.Core.Domain.Enumerations;
using MongoDB.Bson;

namespace Domic.Persistence.Models;

public class SystemExceptionQueryModel
{
    public BsonInt64 Id      { get; set; }
    public string Service    { get; set; }
    public string Action     { get; set; }
    public string Message    { get; set; }
    public string Exception  { get; set; }
    
    public BsonDateTime CreatedAt_EnglishDate { get; set; }
    public string CreatedAt_PersianDate { get; set; }
}