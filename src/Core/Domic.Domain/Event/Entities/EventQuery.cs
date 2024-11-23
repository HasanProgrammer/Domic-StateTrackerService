using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Core.Domain.Entities;

public class EventQuery : BaseEntityQuery<string>
{
    public string Type    { get; set; } //Name Of Event
    public string Service { get; set; } //Name Of Service
    public string Payload { get; set; }
    public string Table   { get; set; }
    public string Action  { get; set; } //CREATE | UPDATE | DELETE
    public string User    { get; set; } //Username
    
    public DateTime CreatedAt_EnglishDate { get; set; }
    public string CreatedAt_PersianDate   { get; set; }
}