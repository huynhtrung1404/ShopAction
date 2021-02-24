using System;
using System.Threading.Tasks;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Common.Interface.Repositories;

namespace ShopAction.Application.Common.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext context;
        public UnitOfWork(IApplicationDbContext context)
        {
            this.context = context;
            ProductRepo = new ProductRepository(this.context);
            CategoryRepo = new CategoryRepository(this.context);
            ProductTranslationRepo = new ProductTranslationRepository(this.context);
            ProductInCategoryRepo = new ProductInCategoryRepository(this.context);
            CategoryTranslationRepo = new CategoryTranslationRepository(this.context);
            LanguageRepo = new LanguageRepository(this.context);
        }
        public IProductRepository ProductRepo { get; set; }

        public ICategoryRepository CategoryRepo { get; set; }

        public IProductTranslationRepository ProductTranslationRepo { get; set; }

        public IProductInCategoryRepository ProductInCategoryRepo { get; set; }

        public ICategoryTranslationRepository CategoryTranslationRepo { get; set; }

        public ILanguageRepository LanguageRepo { get; set; }

        public async Task<int> Completed()
        {
            return await context.SaveChangeAsync();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
