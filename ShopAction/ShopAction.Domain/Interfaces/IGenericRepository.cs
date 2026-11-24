using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAction.Domain.Interfaces
{
    public interface IGenericRepository<TEntity, TId> where TEntity : class
    {

        Task<TEntity> FindByIdAsync(TId id, CancellationToken cancellationToken = default);

        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task AddRangeAsync(IEnumerable<TEntity> entity);

        void DeleteRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> item, CancellationToken cancellationToken);

        Task<TEntity> GetItemAsync(ISpecification<TEntity> item, CancellationToken cancellationToken);

        Task<int> CountAllAsync(ISpecification<TEntity> item, CancellationToken cancellationToken);

    }
}
