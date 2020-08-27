using ShopAction.Data.Ef;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopAction.ViewModels.Commons;
using ShopAction.ViewModels.Catalog.Products;

namespace ShopAction.ApplicationService.Catalog.Products
{

    public class PublicProductService : IPublicProductService
    {
        private readonly ApplicationDbContext context;
        public PublicProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var query = from p in context.Products
                        join pt in context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in context.ProductInCategories on p.Id equals pic.ProductId
                        join c in context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            var data = await query.Select(p => new ProductViewModel()
            {
                Id = p.p.Id,
                Name = p.pt.Name,
                DateCreated = p.p.DateCreated,
                Description = p.pt.Description,
                Details = p.pt.Details,
                LanguageId = p.pt.LanguageId.ToString(),
                OriginalPrice = p.p.OriginalPrice,
                Price = p.p.Price,
                SeoAlias = p.pt.SeoAlias,
                SeoDescription = p.pt.SeoDescription,
                SeoTitle = p.pt.SeoTitle,
                Stock = p.p.Stock,
                ViewCount = p.p.ViewCount
            }).ToListAsync();
            return data;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(Guid languageId,GetPublicProductPagingRequest request)
        {
            var query = from p in context.Products
                        join pt in context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in context.ProductInCategories on p.Id equals pic.ProductId
                        join c in context.Categories on pic.CategoryId equals c.Id
                        where pt.LanguageId == languageId
                        select new { p, pt, pic };
            if (request.CategoryId.HasValue && request.CategoryId.Value != Guid.Empty)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(p => new ProductViewModel()
            {
                Id = p.p.Id,
                Name = p.pt.Name,
                DateCreated = p.p.DateCreated,
                Description = p.pt.Description,
                Details = p.pt.Details,
                LanguageId = p.pt.LanguageId.ToString(),
                OriginalPrice = p.p.OriginalPrice,
                Price = p.p.Price,
                SeoAlias = p.pt.SeoAlias,
                SeoDescription = p.pt.SeoDescription,
                SeoTitle = p.pt.SeoTitle,
                Stock = p.p.Stock,
                ViewCount = p.p.ViewCount
            }).ToListAsync();

            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

    }
}
