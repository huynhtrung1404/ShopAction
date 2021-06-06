using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopAction.Domain.Interfaces;

namespace ShopAction.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private bool _disposed;
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext context)
        {
            _dbContext = context;
        }

        private DbConnection DbConnection => _dbContext.Database.GetDbConnection();

        public IDisposable BeginTransaction(IsolationLevel level)
        {
            throw new NotImplementedException();
        }

        public void CommitChange()
        {
            throw new NotImplementedException();
        }

        public Task CommitChangeAsync()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
