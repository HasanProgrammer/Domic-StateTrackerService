using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Request.Entities;

public class LogQuery : BaseEntityQuery<string>
{
    public string UniqueKey   { get; set; }
    public string ServiceName { get; set; }
    public object Item        { get; set; }
}