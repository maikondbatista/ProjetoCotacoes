using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cotacoes.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Add(TEntity obj, CancellationToken cancellationToken);
        Task Add(IEnumerable<TEntity> obj, CancellationToken cancellationToken);
        IQueryable<TEntity> GetAll();
        Task<TEntity> Update(TEntity obj, CancellationToken cancellationToken);
        Task Delete(long id, CancellationToken cancellationToken);
    }
}
