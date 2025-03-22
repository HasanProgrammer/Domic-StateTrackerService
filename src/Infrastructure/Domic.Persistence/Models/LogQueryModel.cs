namespace Domic.Persistence.Models;

public class LogQueryModel
{
    public string UniqueKey   { get; set; }
    public string ServiceName { get; set; }
    public object Item        { get; set; }
}