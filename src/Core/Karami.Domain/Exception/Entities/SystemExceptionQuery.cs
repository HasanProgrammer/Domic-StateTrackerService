using Karami.Core.Domain.Contracts.Abstracts;
using Karami.Core.Domain.Enumerations;
using MongoDB.Bson;

namespace Karami.Domain.Exception.Entities;

public class SystemExceptionQuery : BaseEntityQuery<ObjectId>
{
    public string Service    { get; set; }
    public string Action     { get; set; }
    public string Message    { get; set; }
    public string Exception  { get; set; }
    public IsActive IsActive { get; set; }
    
    public BsonDateTime CreatedAt_EnglishDate { get; set; }
    public string CreatedAt_PersianDate       { get; set; }
    public BsonDateTime UpdatedAt_EnglishDate { get; set; }
    public string UpdatedAt_PersianDate       { get; set; }
}