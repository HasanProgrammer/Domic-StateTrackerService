using System.Data;
using Domic.Domain.Commons.Contracts.Interfaces;
using MongoDB.Driver;

namespace Domic.Infrastructure.Implementations.Domain.Repositories;

public class QueryUnitOfWork(MongoClient client) : IQueryUnitOfWork
{
    public void Transaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted){}

    public Task TransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted,
        CancellationToken cancellationToken = new CancellationToken()
    ) => Task.CompletedTask;

    public void Commit(){}

    public Task CommitAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public void Rollback(){}

    public Task RollbackAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public void Dispose(){}

    public ValueTask DisposeAsync() => ValueTask.CompletedTask;
}