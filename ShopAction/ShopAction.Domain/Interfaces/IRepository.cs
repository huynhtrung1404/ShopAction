using System;
namespace ShopAction.Domain.Interfaces
{
    public interface IRepository<TEntity,TId> : IGenericRepository<TEntity,TId> where TEntity:class
    {
    }
}
