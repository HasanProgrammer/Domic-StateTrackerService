﻿using Domic.Core.Domain.Contracts.Abstracts;
using MongoDB.Bson;

namespace Domic.Domain.Request.Entities;

public class SystemRequestQuery : BaseEntityQuery<ObjectId>
{
    public string IpClient { get; set; }
    public string Service  { get; set; }
    public string Action   { get; set; }
    public string Header   { get; set; }
    public string Payload  { get; set; }
    
    public BsonDateTime CreatedAt_EnglishDate { get; set; }
    public string CreatedAt_PersianDate       { get; set; }
}