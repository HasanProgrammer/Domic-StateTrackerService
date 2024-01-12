using Karami.Core.UseCase.Contracts.Interfaces;
using Karami.Domain.Exception.Contracts.Interfaces;
using Karami.Domain.Exception.Entities;

using SystemException = Karami.Core.Domain.Entities.SystemException;

namespace Karami.UseCase.ExceptionUseCase.Events;

public class ExceptionLogConsumerEventBusHandler : IConsumerMessageBusHandler<SystemException>
{
    private readonly IExceptionQueryRepository _exceptionQueryRepository;

    public ExceptionLogConsumerEventBusHandler(IExceptionQueryRepository exceptionQueryRepository) 
        => _exceptionQueryRepository = exceptionQueryRepository;
    
    public void Handle(SystemException message)
    {
        var exceptionQuery = new SystemExceptionQuery {
            Service   = message.Service   ,
            Action    = message.Action    ,
            Message   = message.Message   ,
            Exception = message.Exception ,
            IsActive  = message.IsActive  ,
            CreatedAt_EnglishDate = message.CreatedAt_EnglishDate ,
            CreatedAt_PersianDate = message.CreatedAt_PersianDate ,
            UpdatedAt_EnglishDate = message.UpdatedAt_EnglishDate ,
            UpdatedAt_PersianDate = message.UpdatedAt_PersianDate
        };
            
        _exceptionQueryRepository.Add(exceptionQuery);
    }
}