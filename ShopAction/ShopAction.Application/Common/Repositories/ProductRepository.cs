using System;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Common.Interface.Repositories;
using ShopAction.Domain.Entities;

namespace ShopAction.Application.Common.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IApplicationDbContext context): base(context)
        {

        }
    }
}
