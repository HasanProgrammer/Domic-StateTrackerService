using Karami.Core.Common.ClassConsts;
using Karami.Core.Domain.Constants;
using Karami.Core.Domain.Entities;
using Karami.Core.UseCase.Contracts.Interfaces;

using SystemException = Karami.Core.Domain.Entities.SystemException;

namespace Karami.WebAPI.Frameworks.Jobs;

public class EventConsumerJob : IHostedService
{
    private readonly IMessageBroker _messageBroker;

    public EventConsumerJob(IMessageBroker messageBroker) => _messageBroker = messageBroker;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _messageBroker.NameOfAction  = nameof(EventConsumerJob);
        _messageBroker.NameOfService = Service.StateTrackerService;

        _messageBroker.Subscribe<SystemRequest>(Broker.StateTracker_Request_Queue);
        _messageBroker.Subscribe<Event>(Broker.StateTracker_Event_Queue);
        _messageBroker.Subscribe<SystemException>(Broker.StateTracker_Exception_Queue);
        _messageBroker.Subscribe<Log>(Broker.StateTracker_Log_Queue);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}