using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAction.Domain.Entities;

namespace ShopAction.Infrastructure.Persistences.Configurations
{
    public class ProductImageConfiguration : AppEntityTypeBaseConfiguration<ProductImage>
    {
        public override void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            base.Configure(builder);
            builder.ToTable("ProductImages");
            builder.Property(x => x.Path).IsRequired();
            builder.Property(x => x.Caption).IsRequired();
        }
    }
}
