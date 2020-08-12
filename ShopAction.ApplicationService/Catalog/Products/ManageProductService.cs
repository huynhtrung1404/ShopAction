using Microsoft.EntityFrameworkCore;
using ShopAction.ApplicationService.Catalog.Products.Dtos;
using ShopAction.ApplicationService.Catalog.Products.Dtos.Manage;
using ShopAction.ApplicationService.Dtos;
using ShopAction.Data.Ef;
using ShopAction.Data.Entities;
using ShopAction.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ShopAction.ApplicationService.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly ApplicationDbContext context;
        public ManageProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddViewCount(Guid productId)
        {
            var product = await context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = Guid.Parse(request.LanguageId)
                    }
                }
            };
            context.Products.Add(product);
            return await context.SaveChangesAsync();
        }


        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            var query = from p in context.Products
                        join pt in context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in context.ProductInCategories on p.Id equals pic.ProductId
                        join c in context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic};
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            }
            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(x => request.CategoryIds.Contains(x.pic.CategoryId));
            }

            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1)*request.PageSize).Take(request.PageSize).Select(p=>new ProductViewModel() { 
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
                Items =  data
            };
            return pagedResult;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product =await context.Products.FindAsync(request.Id);
            var productTranslation = await context.ProductTranslations.FirstOrDefaultAsync(x=>x.ProductId == request.Id && x.LanguageId == request.LanguageId);
            if (product==null || productTranslation == null)
            {
                throw new ShopActionException($"Cannot find a product with Id: {request.Id}");
            }
            productTranslation.Name = request.Name;
            productTranslation.SeoAlias = request.SeoAlias;
            productTranslation.SeoDescription = request.SeoDescription;
            productTranslation.SeoTitle = request.SeoTitle;
            productTranslation.Description = request.Description;
            productTranslation.Details = request.Details;
            return await context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(Guid productId, decimal newPrice)
        {
            var product = await context.Products.FindAsync(productId);
            if (product == null) throw new ShopActionException($"not find product with id: {productId}");
            product.Price = newPrice;
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(Guid productId, int addedQuantity)
        {
            var product = await context.Products.FindAsync(productId);
            if (product == null) throw new ShopActionException($"not find product with id: {productId}");
            product.Stock += addedQuantity;
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<int> Delete(Guid productId)
        {
            var product = await context.Products.FindAsync(productId);
            if (product == null) throw new ShopActionException($"Cannot find a product with Id: {product}");
            context.Products.Remove(product);
            return await context.SaveChangesAsync();
        }

    }
}
