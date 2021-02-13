using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Common.Interface.Repositories;

namespace ShopAction.Application.Common.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IApplicationDbContext context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(IApplicationDbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IQueryable<T> entitites)
        {
            await dbSet.AddRangeAsync(entitites);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public IQueryable<T> GetAllData()
        {
            return dbSet.AsQueryable<T>();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IQueryable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
