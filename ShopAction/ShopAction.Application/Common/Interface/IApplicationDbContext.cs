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
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<ProductInCategory> ProductInCategories { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<Employee> Employees { get; set; }

        Task<int> SaveChangeAsync(CancellationToken cancellationToken = new CancellationToken());
        DbSet<T> Set<T>() where T : class;
        void Dispose();
    }
}
