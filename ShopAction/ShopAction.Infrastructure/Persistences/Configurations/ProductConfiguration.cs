using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAction.Domain.Entities;

namespace ShopAction.Infrastructure.Persistences.Configurations
{
    public class ProductConfiguration : AppEntityTypeBaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.ToTable("Products");
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
