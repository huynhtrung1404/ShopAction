using System;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Common.Interface.Repositories;
using ShopAction.Domain.Entities;

namespace ShopAction.Application.Common.Repositories
{
    public class CategoryTranslationRepository:GenericRepository<CategoryTranslation>, ICategoryTranslationRepository
    {
        public CategoryTranslationRepository(IApplicationDbContext context): base(context)
        {
        }
    }
}
