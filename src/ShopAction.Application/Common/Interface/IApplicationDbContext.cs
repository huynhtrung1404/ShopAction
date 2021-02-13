using Microsoft.EntityFrameworkCore;
using ShopAction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopAction.Application.Common.Interface
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<AppConfig> AppConfigs { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<ProductTranslation> ProductTranslations { get; set; }
        DbSet<Promotion> Promotions { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<ProductInCategory> ProductInCategories { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }

        Task<int> SaveChangeAsync(CancellationToken cancellationToken = new CancellationToken());
        DbSet<T> Set<T>() where T:class;
        void Dispose();
    }
}
