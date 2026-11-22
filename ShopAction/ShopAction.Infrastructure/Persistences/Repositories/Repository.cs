using System;
using ShopAction.Domain.Interfaces;

namespace ShopAction.Infrastructure.Persistence.Repositories
{
    public class Repository<TEntity, TId> : GenericRepository<TEntity, TId>, IRepository<TEntity, TId> where TEntity : class
    {
        public Repository(AppDbContext context) : base(context)
        {

        }
    }
}
