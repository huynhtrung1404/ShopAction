using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAction.Domain.Entities;

namespace ShopAction.Infrastructure.Persistence.Configuration
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(x => new { x.CategoryId, x.ProductId });
            builder.ToTable("ProductInCategories");
            builder.HasOne(x => x.Product).WithMany(p => p.ProductInCategories).HasForeignKey(p => p.ProductId);
            builder.HasOne(x => x.Category).WithMany(p => p.ProductInCategories).HasForeignKey(p => p.CategoryId);
        }
    }
}