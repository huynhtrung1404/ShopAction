using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAction.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.Data.Configuration
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(x => new { x.CategoryId, x.ProductId });
            builder.ToTable("ProductInCategories");
            builder.HasOne(x => x.Product).WithMany(p => p.ProductInCategories).HasForeignKey(p => p.ProductId);
            builder.HasOne(x => x.Category).WithMany(c => c.ProductInCategories).HasForeignKey(p => p.CategoryId);
        }
    }
}
