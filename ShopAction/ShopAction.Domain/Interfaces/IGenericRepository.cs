using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopAction.Domain.Interfaces
{
    public interface IGenericrepository<TEntity, TId> where TEntity:class
    {
        Task<IEnumerable<TEntity>> GetAllData();

        Task<TEntity> FindByIdAsync(TId id);

        Task<bool> AddAsync(TEntity entity);

        Task<bool> AddRangeAsync(IEnumerable<TEntity> entity);

        Task DeleteAsync(TId id);

        Task DeleteRangeAsync(IList<TId> ids);

        void Delete(TId id);

        void DeleteRange(IEnumerable<TId> id);

        Task<bool> UpdateAsync(TEntity entity);

        Task<bool> UpdateRangeAsync(IEnumerable<TEntity> entitties);
    }
}
