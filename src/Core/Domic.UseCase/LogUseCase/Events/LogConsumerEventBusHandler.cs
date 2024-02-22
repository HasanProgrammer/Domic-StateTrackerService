using Domic.Core.Domain.Constants;
using Domic.Core.Domain.Entities;
using Domic.Core.UseCase.Commons.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Request.Contracts.Interfaces;
using Domic.Domain.Request.Entities;

namespace Domic.UseCase.EventUseCase.Events;

[Consumer(Queue = Broker.StateTracker_Log_Queue)]
public class LogConsumerEventBusHandler : IConsumerMessageBusHandler<Log>
{
    private readonly ILogQueryRepository _logQueryRepository;

    public LogConsumerEventBusHandler(ILogQueryRepository logQueryRepository) 
        => _logQueryRepository = logQueryRepository;
    
    public void Handle(Log message)
    {
        var logQuery = new LogQuery {
            UniqueKey   = message.UniqueKey   ,
            ServiceName = message.ServiceName ,
            Item        = message.Item
        };
        
        _logQueryRepository.Add(logQuery);
    }
}