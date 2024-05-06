using System.Data;
using Domic.Domain.Commons.Contracts.Interfaces;
using MongoDB.Driver;

namespace Domic.Infrastructure.Implementations.Domain.Repositories;

public class QueryUnitOfWork(MongoClient client) : IQueryUnitOfWork
{
    private IClientSessionHandle _clientSession;

    public void Transaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
    {
        _clientSession = client.StartSession(); //Resource
        _clientSession.StartTransaction();
    }

    public void Commit() => _clientSession?.CommitTransaction();

    public void Rollback() => _clientSession?.AbortTransaction();

    public void Dispose() => _clientSession?.Dispose();
}