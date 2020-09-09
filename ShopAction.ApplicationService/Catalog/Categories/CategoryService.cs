using ShopAction.Data.Ef;
using ShopAction.ViewModels.Catalog.Categories;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ShopAction.ApplicationService.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext context;
        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Task<bool> DeleteCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryViewModel>> GetAllCategory()
        {
            var query = from c in context.Categories
                        join ct in context.CategoryTranslations on c.Id equals ct.CategoryId
                        select new { c,ct};
            var result = await query.Select(x => new CategoryViewModel
            {
                Id = x.c.Id,
                LanguageId = x.ct.LanguageId.ToString(),
                Name = x.ct.Name
            }).ToListAsync();
            return result;
                        
        }

        public async Task<bool> UpdateCategory(Guid id)
        {
            var category = await context.Categories.FindAsync(id);
        }
    }
}
