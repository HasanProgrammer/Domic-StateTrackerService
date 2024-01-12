using Karami.Core.Domain.Contracts.Interfaces;
using Karami.Core.Domain.Entities;
using Karami.Core.UseCase.Contracts.Interfaces;

namespace Karami.UseCase.EventUseCase.Events;

public class EventLogConsumerEventBusHandler : IConsumerMessageBusHandler<Event>
{
    private readonly IEventQueryRepository _eventQueryRepository;

    public EventLogConsumerEventBusHandler(IEventQueryRepository eventQueryRepository) 
        => _eventQueryRepository = eventQueryRepository;
    
    public void Handle(Event message)
    {
        var eventQuery = new EventQuery {
            Type    = message.Type    ,
            Service = message.Service ,
            Payload = message.Payload ,
            Table   = message.Table   ,
            Action  = message.Action  ,
            User    = message.User    ,
            CreatedAt_EnglishDate = message.CreatedAt_EnglishDate ,
            CreatedAt_PersianDate = message.CreatedAt_PersianDate ,
            UpdatedAt_EnglishDate = message.UpdatedAt_EnglishDate ,
            UpdatedAt_PersianDate = message.UpdatedAt_PersianDate
        };
        
        _eventQueryRepository.Add(eventQuery);
    }
}