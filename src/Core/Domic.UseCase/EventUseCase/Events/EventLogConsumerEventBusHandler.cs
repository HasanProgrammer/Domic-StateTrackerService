using Domic.Core.Common.ClassConsts;
using Domic.Core.Domain.Constants;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.Entities;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Commons.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.EventUseCase.Events;

[Consumer(Queue = Broker.StateTracker_Event_Queue)]
public class EventLogConsumerEventBusHandler : IConsumerMessageBusHandler<Event>
{
    private readonly IEventQueryRepository _eventQueryRepository;

    public EventLogConsumerEventBusHandler(IEventQueryRepository eventQueryRepository) 
        => _eventQueryRepository = eventQueryRepository;
    
    public void Handle(Event message){}

    [TransactionConfig(Type = TransactionType.Query)]
    public Task HandleAsync(Event message, CancellationToken cancellationToken)
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

        return Task.CompletedTask;
    }
}