using Domic.Domain.Exception.Entities;
using Domic.Core.Domain.Contracts.Interfaces;

namespace Domic.Domain.Exception.Contracts.Interfaces;

public interface IExceptionQueryRepository : IQueryRepository<SystemExceptionQuery, string>;