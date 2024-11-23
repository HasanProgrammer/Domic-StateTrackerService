using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Request.Entities;

public class SystemRequestQuery : BaseEntityQuery<string>
{
    public string IpClient { get; set; }
    public string Service  { get; set; }
    public string Action   { get; set; }
    public string Header   { get; set; }
    public string Payload  { get; set; }
    
    public DateTime CreatedAt_EnglishDate { get; set; }
    public string CreatedAt_PersianDate   { get; set; }
}