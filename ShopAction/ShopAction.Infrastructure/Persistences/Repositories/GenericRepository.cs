﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopAction.Application.Common.Extensions;
using ShopAction.Domain.Interfaces;

namespace ShopAction.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class
    {
        public DbContext DbContext { get; }

        public IQueryable<TEntity> DbSet { get; }

        public GenericRepository(DbContext context)
        {
            DbContext = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbContext.Set<TEntity>().ToListAsync();
        }

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

        public void UpdateRange(IEnumerable<TEntity> entitties)
        {
            DbContext.Set<TEntity>().UpdateRange(entitties);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().RemoveRange(entities);
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllIncludePagingAsync(int pageSize, int pageNumber)
        {
            return await DbContext.Set<TEntity>().ToPaginationAsync(pageSize, pageNumber);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TItem>(Expression<Func<TEntity, TItem>> predicate, int pageSize, int pageNumber) where TItem : class
        {
            return await DbContext.Set<TEntity>().Include(predicate).ToPaginationAsync(pageSize, pageNumber);
        }
    }
}
