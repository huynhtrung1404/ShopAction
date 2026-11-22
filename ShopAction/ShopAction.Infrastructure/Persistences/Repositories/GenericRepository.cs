using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopAction.Domain.Interfaces;
using ShopAction.Infrastructure.Extensions;

namespace ShopAction.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<TEntity, TId>(DbContext context) : IGenericRepository<TEntity, TId> where TEntity : class
    {
        public DbContext DbContext { get; } = context;

        public IQueryable<TEntity> DbSet { get; } = context.Set<TEntity>();

        public async Task<TEntity> FindByIdAsync(TId id)
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entity)
        {
            await DbContext.Set<TEntity>().AddRangeAsync(entity);
        }

        public void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().UpdateRange(entities);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().RemoveRange(entities);
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> item, CancellationToken cancellationToken)
        {
            return await DbContext.Set<TEntity>().ApplySpecification(item).ToListAsync(cancellationToken);
        }

        public async Task<int> CountAllAsync(ISpecification<TEntity> item, CancellationToken cancellationToken)
        {
            return await DbContext.Set<TEntity>().ApplySpecificationForCount(item).CountAsync(cancellationToken);
        }

        public async Task<TEntity> GetItemAsync(ISpecification<TEntity> item, CancellationToken cancellationToken)
        {
            return await DbContext.Set<TEntity>().ApplySpecification(item).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
