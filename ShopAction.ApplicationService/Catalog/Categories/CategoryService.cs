using ShopAction.Data.Ef;
using ShopAction.ViewModels.Catalog.Categories;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using ShopAction.Utilities.Exceptions;
using ShopAction.Data.Enum;
using ShopAction.Data.Entities;

namespace ShopAction.ApplicationService.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext context;
        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddNewCategory(AddCategoryRequest request)
        {
            if (request == null)
            {
                throw new ShopActionException("Invalid data");
            }
            var result = new Category
            {
                Status = (Status)Enum.Parse(typeof(Status), request.Status, true),
                SortOrder = request.SortOrder,
                IsShowOnHome = request.IsShowOnHome,
            };
            result.CategoryTranslations = new List<CategoryTranslation>()
            {
                new CategoryTranslation
                {
                    CategoryId = result.Id,
                    LanguageId = request.LanguageId,
                    Name = request.Name,
                    SeoAlias = request.SeoAlias,
                    SeoDescription = request.SeoDescription,
                    SeoTitle = request.SeoTitle,
                    Id = new Guid()
                }
            };
            context.Categories.Add(result);
            return await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new ShopActionException("This category isn't existing");
            }
            if (category.Status == Status.InActive)
            {
                throw new ShopActionException("This category is deleted before");
            }
            category.Status = Status.InActive;
            category.IsShowOnHome = false;
            return await context.SaveChangesAsync() > 0;
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

        public async Task<int> UpdateCategory(UpdateCategoryRequest request)
        {
            var category = await context.Categories.FindAsync(request.Id);
            var translation = await context.CategoryTranslations.FirstOrDefaultAsync(y => y.CategoryId == request.Id);
            if (category == null)
            {
                throw new ShopActionException($"Category with id {request.Id} is not found ");
            }
            category.IsShowOnHome = request.IsShowOnHome;
            translation.LanguageId = request.LanguageId;
            translation.Name = request.Name;
            translation.SeoTitle = request.SeoTitle;
            translation.SeoDescription = request.SeoDescription;

            return await context.SaveChangesAsync();
        }

    }
}
