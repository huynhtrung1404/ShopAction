using System;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Common.Interface.Repositories;
using ShopAction.Domain.Entities;

namespace ShopAction.Application.Common.Repositories
{
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IApplicationDbContext context):base(context)
        {
        }
    }
}
