using Domic.Core.Common.ClassEnums;
using Domic.Core.Domain.Constants;
using Domic.Core.Domain.Entities;
using Domic.Core.UseCase.Attributes;
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

    public Task BeforeHandleAsync(Log message, CancellationToken cancellationToken) => Task.CompletedTask;

    [TransactionConfig(Type = TransactionType.Query)]
    public Task HandleAsync(Log message, CancellationToken cancellationToken)
    {
        var logQuery = new LogQuery {
            UniqueKey   = message.UniqueKey   ,
            ServiceName = message.ServiceName ,
            Item        = message.Item
        };
        
        _logQueryRepository.Add(logQuery);

        return Task.CompletedTask;
    }

    public Task AfterHandleAsync(Log message, CancellationToken cancellationToken)
        => Task.CompletedTask;
}