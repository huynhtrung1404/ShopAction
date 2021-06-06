using System;
using ShopAction.Domain.Interfaces;

namespace ShopAction.Infrastructure.Persistences.Repositories
{
    public class Repository<TEntity, TId> : GenericRepository<TEntity,TId>, IRepository<TEntity,TId> where TEntity:class
    {
        public Repository(AppDbContext context) : base(context)
        {

        }
    }
}
