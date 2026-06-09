using System;
using System.Threading;
using System.Threading.Tasks;

namespace OfferHub.Application.Common.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
