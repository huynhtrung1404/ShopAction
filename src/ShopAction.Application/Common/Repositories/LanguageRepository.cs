using System;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Common.Interface.Repositories;
using ShopAction.Domain.Entities;

namespace ShopAction.Application.Common.Repositories
{
    public class LanguageRepository:GenericRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(IApplicationDbContext context) :base(context)
        {
        }
    }
}
