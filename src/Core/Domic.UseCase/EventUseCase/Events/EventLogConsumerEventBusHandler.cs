using Domic.Core.Common.ClassEnums;
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

    public Task BeforeHandleAsync(Event message, CancellationToken cancellationToken) => Task.CompletedTask;

    [TransactionConfig(Type = TransactionType.Query)]
    public Task HandleAsync(Event message, CancellationToken cancellationToken)
    {
        var eventQuery = new EventQuery {
            Id      = message.Id      , 
            Type    = message.Type    ,
            Service = message.Service ,
            Payload = message.Payload ,
            Table   = message.Table   ,
            Action  = message.Action  ,
            User    = message.User    ,
            CreatedAt_EnglishDate = message.CreatedAt_EnglishDate ,
            CreatedAt_PersianDate = message.CreatedAt_PersianDate
        };
        
        _eventQueryRepository.Add(eventQuery);

        return Task.CompletedTask;
    }

    public Task AfterHandleAsync(Event message, CancellationToken cancellationToken)
        => Task.CompletedTask;
}