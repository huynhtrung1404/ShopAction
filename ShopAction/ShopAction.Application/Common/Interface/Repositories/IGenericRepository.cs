using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopAction.Application.Common.Interface.Repositories
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAllData();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task AddRangeAsync(IQueryable<T> entitites);
        void Remove(T entity);
        void RemoveRange(IQueryable<T> entitites);
        IQueryable<T> Find(Expression<Func<T,bool>> predicate);
    }
}
