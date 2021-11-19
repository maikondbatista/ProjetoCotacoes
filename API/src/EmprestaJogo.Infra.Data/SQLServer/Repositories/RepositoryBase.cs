using Cotacoes.Domain.Interfaces.Repositories;
using Cotacoes.Infra.Data.SQLServer.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cotacoes.Infra.Data.SQLServer.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly CotacaoContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(CotacaoContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public async virtual Task<TEntity> Add(TEntity obj, CancellationToken cancellationToken)
        {
            var entity = (await DbSet.AddAsync(obj, cancellationToken)).Entity;

            await SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async virtual Task Add(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            if (!entities.Any() || entities is null)
                throw new ArgumentNullException(nameof(entities));

            await DbSet.AddRangeAsync(entities, cancellationToken);
            await SaveChangesAsync(cancellationToken);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().AsQueryable();
        }

        public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }

        public async virtual Task<TEntity> Update(TEntity obj, CancellationToken cancellationToken)
        {
            var entity = DbSet.Update(obj).Entity;

            await SaveChangesAsync(cancellationToken);

            return entity;
        }
        public async Task Delete(long id, CancellationToken cancellationToken)
        {
            var obj = await DbSet.FindAsync(id);
            if (obj != null)
            {
                DbSet.Remove(obj);
                await SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await Db.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
