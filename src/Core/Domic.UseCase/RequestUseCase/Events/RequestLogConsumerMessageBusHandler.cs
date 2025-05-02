using Domic.Core.Common.ClassEnums;
using Domic.Core.Domain.Constants;
using Domic.Core.Domain.Entities;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Commons.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Request.Contracts.Interfaces;
using Domic.Domain.Request.Entities;

namespace Domic.UseCase.RequestUseCase.Events;

[Consumer(Queue = Broker.StateTracker_Request_Queue)]
public class RequestLogConsumerMessageBusHandler : IConsumerMessageBusHandler<SystemRequest>
{
    private readonly IRequestQueryRepository _requestQueryRepository;

    public RequestLogConsumerMessageBusHandler(IRequestQueryRepository requestQueryRepository) 
        => _requestQueryRepository = requestQueryRepository;

    public Task BeforeHandleAsync(SystemRequest message, CancellationToken cancellationToken) => Task.CompletedTask;

    [TransactionConfig(Type = TransactionType.Query)]
    public Task HandleAsync(SystemRequest message, CancellationToken cancellationToken)
    {
        var requestQuery = new SystemRequestQuery {
            IpClient = message.IpClient ,
            Service  = message.Service  ,
            Action   = message.Action   ,
            Header   = message.Header   ,
            Payload  = message.Payload  ,
            CreatedAt_EnglishDate = message.CreatedAt_EnglishDate ,
            CreatedAt_PersianDate = message.CreatedAt_PersianDate
        };
            
        _requestQueryRepository.Add(requestQuery);

        return Task.CompletedTask;
    }

    public Task AfterHandleAsync(SystemRequest message, CancellationToken cancellationToken)
        => Task.CompletedTask;
}