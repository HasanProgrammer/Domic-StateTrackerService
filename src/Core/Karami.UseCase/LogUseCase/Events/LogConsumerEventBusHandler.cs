using Karami.Core.Domain.Entities;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Domain.Request.Contracts.Interfaces;
using Karami.Domain.Request.Entities;

namespace Karami.UseCase.EventUseCase.Events;

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