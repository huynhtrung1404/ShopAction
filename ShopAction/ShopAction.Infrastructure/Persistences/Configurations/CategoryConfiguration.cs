using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAction.Domain.Entities;

namespace ShopAction.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : AppEntityTypeBaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.ToTable("Categories");
        }
    }
}
