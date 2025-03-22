using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Enumerations;

namespace Domic.Domain.Exception.Entities;

public class SystemExceptionQuery : BaseEntityQuery<string>
{
    public string Service    { get; set; }
    public string Action     { get; set; }
    public string Message    { get; set; }
    public string Exception  { get; set; }
    public IsActive IsActive { get; set; }
    
    public DateTime CreatedAt_EnglishDate { get; set; }
    public string CreatedAt_PersianDate   { get; set; }
}