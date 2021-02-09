using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ShopAction.Domain.Entities;
using ShopAction.Domain.Enum;
using ShopAction.Infrastructure.Identity.Models;

namespace ShopAction.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeedData
    {
        public static async Task SeedMigrationDataAsync(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>(){
                    new Product()
                    {
                        Id = Guid.NewGuid(),
                        Stock = 3,
                        Price = 22,
                        OriginalPrice =44,
                        SeoAlias = "Ao nam"
                    },
                    new Product()
                    {
                        Id = Guid.NewGuid(),
                        Stock = 1,
                        Price = 23,
                        OriginalPrice = 42312,
                        SeoAlias = "Original Ao"
                    },
                    new Product()
                    {
                        Id = Guid.NewGuid(),
                        Stock = 0,
                        Price = 12,
                        OriginalPrice = 12,
                        SeoAlias = "Ao nu"
                    }
                };
                var categories = new List<Category>()
                {
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        IsShowOnHome = true,
                        SortOrder = 2,
                        Status = Status.Active
                    },
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        IsShowOnHome = true,
                        SortOrder = 1,
                        Status = Status.Active
                    }
                };
                var languages = new List<Language>()
                {
                    new Language()
                    {
                        Id = Guid.NewGuid(),
                         Name = "Eng",
                         IsDefault =true, 
                    },
                    new Language()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Vie",
                        IsDefault = false
                    }
                };

                var productTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Id = Guid.NewGuid(),
                        ProductId = products[0].Id,
                        SeoTitle = "ao-nam-mau-1",
                        SeoAlias = "Áo nam",
                        SeoDescription = "Sản phẩm",
                        Description = "San pham",
                        LanguageId = languages[0].Id
                    },
                    new ProductTranslation()
                    {
                        Id = Guid.NewGuid(),
                        ProductId = products[1].Id,
                        SeoTitle = "ao-mau-2",
                        SeoAlias = "Original Ao",
                        SeoDescription = "Sản phẩm",
                        Description = "Sản Phẩm",
                        LanguageId = languages[0].Id
                    },
                    new ProductTranslation()
                    {
                        Id = Guid.NewGuid(),
                        ProductId = products[1].Id,
                        SeoTitle = "ao-mau-3",
                        SeoAlias = "Ao Mau",
                        SeoDescription = "Sản phẩm",
                        Description = "Sản Phẩm",
                        LanguageId = languages[0].Id
                    }
                };
                var categoryTranslation = new List<CategoryTranslation>()
                {
                    new CategoryTranslation()
                    {
                        Id = Guid.NewGuid(),
                         CategoryId = categories[0].Id,
                         Name = "T-shirt",
                         LanguageId = languages[0].Id,
                          SeoTitle = "t-shirt",
                          SeoAlias = "T-Shirt",
                          SeoDescription = "T-Shirt"
                    },
                    new CategoryTranslation()
                    {
                        Id = Guid.NewGuid(),
                         CategoryId = categories[1].Id,
                         Name = "Wearable",
                         LanguageId = languages[0].Id,
                          SeoTitle = "Wear",
                          SeoAlias = "Wear",
                          SeoDescription = "Wear"
                    }
                };
                var productInCategory = new List<ProductInCategory> {
                      new ProductInCategory()
                      {
                           CategoryId = categories[0].Id,
                           ProductId = products[0].Id
                      },
                      new ProductInCategory()
                      {
                           CategoryId = categories[0].Id,
                           ProductId = products[1].Id
                      },
                      new ProductInCategory()
                      {
                           CategoryId = categories[1].Id,
                           ProductId = products[1].Id
                      }
                };

                await context.Languages.AddRangeAsync(languages);
                await context.Products.AddRangeAsync(products);
                await context.Categories.AddRangeAsync(categories);
                await context.ProductTranslations.AddRangeAsync(productTranslations);
                await context.CategoryTranslations.AddRangeAsync(categoryTranslation);
                await context.ProductInCategories.AddRangeAsync(productInCategory);
                var cancellationToken = new CancellationToken();
                await context.SaveChangeAsync(cancellationToken);

            }
        }
    }
}
