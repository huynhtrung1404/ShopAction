using System;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Common.Interface.Repositories;
using ShopAction.Domain.Entities;

namespace ShopAction.Application.Common.Repositories
{
    public class ProductTranslationRepository:GenericRepository<ProductTranslation>, IProductTranslationRepository
    {
        public ProductTranslationRepository(IApplicationDbContext context) : base(context)
        {
        }
    }
}
