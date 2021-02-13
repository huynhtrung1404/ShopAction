using System;
using System.Threading.Tasks;
using ShopAction.Application.Common.Interface.Repositories;

namespace ShopAction.Application.Common.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository ProductRepo { get; }
        ICategoryRepository CategoryRepo { get; }
        IProductTranslationRepository ProductTranslationRepo { get; }
        IProductInCategoryRepository ProductInCategoryRepo { get;  }
        ICategoryTranslationRepository CategoryTranslationRepo { get; }
        ILanguageRepository LanguageRepo { get; }
        Task<int> Completed();
    }
}
