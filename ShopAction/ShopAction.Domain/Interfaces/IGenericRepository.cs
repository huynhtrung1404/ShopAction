using System;
using System.Collections.Generic;
using System.Linq;
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

        Task<IEnumerable<TEntity>> GetAllAndPagingAsync(int pageSize, int pageNumber);

    }
}
