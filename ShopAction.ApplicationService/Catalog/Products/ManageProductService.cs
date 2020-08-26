using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShopAction.ApplicationService.Common;
using ShopAction.Data.Ef;
using ShopAction.Data.Entities;
using ShopAction.Utilities.Exceptions;
using ShopAction.ViewModels.Catalog.Products;
using ShopAction.ViewModels.Commons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShopAction.ApplicationService.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly ApplicationDbContext context;
        private readonly IStorageService storage;
        public ManageProductService(ApplicationDbContext context, IStorageService storage)
        {
            this.context = context;
            this.storage = storage;
        }

        public async Task AddViewCount(Guid productId)
        {
            var product = await context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await context.SaveChangesAsync();
        }

        public async Task<Guid> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Id = new Guid(),
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Id = new Guid(),
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = Guid.Parse(request.LanguageId)
                    }
                }
            };

            if (request.Img != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Id = Guid.NewGuid(),
                        Caption = "Thumnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.Img.Length,
                        Path = await this.SaveFile(request.Img),
                        IsDefault = true,
                        SortOrder = 1
                        
                    }
                };
            }
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return product.Id;
        }


        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
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
            if (request.Img != null)
            {
                var thumb = context.ProductImages.FirstOrDefault(i => i.IsDefault == true && i.ProductId == request.Id);
                if (thumb != null)
                {
                    thumb.FileSize = request.Img.Length;
                    thumb.Path = await this.SaveFile(request.Img);
                    context.ProductImages.Update(thumb);
                }
            }
            return await context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(Guid productId, decimal newPrice)
        {
            var product = await context.Products.FindAsync(productId);
            if (product == null) throw new ShopActionException($"not find product with id: {productId}");
            product.Price = newPrice;
            context.Products.Update(product);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(Guid productId, int addedQuantity)
        {
            var product = await context.Products.FindAsync(productId);
            if (product == null) throw new ShopActionException($"not find product with id: {productId}");
            product.Stock += addedQuantity;
            context.Products.Update(product);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<int> Delete(Guid productId)
        {
            var product = await context.Products.FindAsync(productId);
            if (product == null) throw new ShopActionException($"Cannot find a product with Id: {product}");

            var thumbs =  context.ProductImages.Where(x => x.ProductId == productId);
            foreach (var thumb in thumbs)
            {
               await storage.DeleteFileAsync(thumb.Path);
            }
            context.Products.Remove(product);

            return await context.SaveChangesAsync();
        }

        public async Task<int> AddImages(Guid productId, List<IFormFile> files)
        {
            var listProduct = new List<ProductImage>();
            foreach (var value in files)
            {
                var productImage = new ProductImage
                {
                    Id = new Guid(),
                    Caption = "",
                    ProductId = productId,
                    FileSize = value.Length,
                    Path = await SaveFile(value),
                    IsDefault = true,
                    SortOrder = 1
                };
                listProduct.Add(productImage);
            }
            await context.ProductImages.AddRangeAsync(listProduct);
            return await context.SaveChangesAsync();
        }

        public async Task<int> RemoveImages(Guid imageId)
        {
            var productImage = await context.ProductImages.FindAsync(imageId);
            if (productImage == null)
            {
                throw new ShopActionException("Doesn't find any picture");
            }
            context.ProductImages.Remove(productImage);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateImage(Guid imageId, string caption, bool isDefault)
        {
            var productImage = await context.ProductImages.FindAsync(imageId);

            if (productImage == null)
            {
                throw new ShopActionException("Doesn't find any image");
            }
            productImage.Caption = caption;
            productImage.IsDefault = isDefault;
            context.ProductImages.Update(productImage);
            return await context.SaveChangesAsync();
        }

        public async Task<ProductViewModel> GetProductById(Guid id, Guid languageId)
        {
            var product = await context.Products.FindAsync(id);
            var productTranslation = await context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == id && x.LanguageId == languageId);
            var productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                DateCreated = product.DateCreated,
                Description = productTranslation.Description,
                LanguageId = productTranslation.LanguageId.ToString() ?? Guid.Empty.ToString(),
                Details = productTranslation?.Details,
                Name = productTranslation?.Name,
                OriginalPrice = product.OriginalPrice,
                Price = product.Price,
                SeoAlias = productTranslation?.SeoAlias,
                SeoDescription = productTranslation?.SeoDescription,
                Stock = product.Stock,
                ViewCount = product.ViewCount
            };
            return productViewModel;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await storage.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<List<ProductImageViewModel>> GetListImage(Guid productId)
        {
            return await context.ProductImages.Where(x => x.ProductId == productId).Select(i => new ProductImageViewModel
            {
                Id = i.Id,
                FilePath = i.Path,
                FileSize = i.FileSize,
                IsDefault = i.IsDefault
            }).ToListAsync();
        }
    }
}
