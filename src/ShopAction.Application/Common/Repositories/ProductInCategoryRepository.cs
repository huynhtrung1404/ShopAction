using System;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Common.Interface.Repositories;
using ShopAction.Domain.Entities;

namespace ShopAction.Application.Common.Repositories
{
    public class ProductInCategoryRepository:GenericRepository<ProductInCategory>, IProductInCategoryRepository
    {
        public ProductInCategoryRepository(IApplicationDbContext context):base(context)
        {
        }
    }
}
