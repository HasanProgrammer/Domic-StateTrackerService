using Karami.Core.Domain.Entities;
using Karami.Core.UseCase.Attributes;
using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Domain.Request.Contracts.Interfaces;
using Karami.Domain.Request.Entities;

namespace Karami.UseCase.RequestUseCase.Events;

public class RequestLogConsumerMessageBusHandler : IConsumerMessageBusHandler<SystemRequest>
{
    private readonly IRequestQueryRepository _requestQueryRepository;

    public RequestLogConsumerMessageBusHandler(IRequestQueryRepository requestQueryRepository) 
        => _requestQueryRepository = requestQueryRepository;
    
    [WithMaxRetry(Count = 5)]
    public void Handle(SystemRequest message)
    {
        var requestQuery = new SystemRequestQuery {
            IpClient = message.IpClient ,
            Service  = message.Service  ,
            Action   = message.Action   ,
            Header   = message.Header   ,
            Payload  = message.Payload  ,
            CreatedAt_EnglishDate = message.CreatedAt_EnglishDate ,
            CreatedAt_PersianDate = message.CreatedAt_PersianDate ,
            UpdatedAt_EnglishDate = message.UpdatedAt_EnglishDate ,
            UpdatedAt_PersianDate = message.UpdatedAt_PersianDate
        };
            
        _requestQueryRepository.Add(requestQuery);
    }
}