using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopAction.Domain.Interfaces
{
    public interface IGenericRepository<TEntity, TId> where TEntity:class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> FindByIdAsync(TId id);

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entity);

        void DeleteRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entitties);

        Task<IEnumerable<TEntity>> GetAllIncludePagingAsync(int pageSize, int pageNumber);

        Task<IEnumerable<TEntity>> GetAllAsync<TItem>(Expression<Func<TEntity,TItem>> predicate, int pageSize, int pageNumber) where TItem : class;

    }
}
