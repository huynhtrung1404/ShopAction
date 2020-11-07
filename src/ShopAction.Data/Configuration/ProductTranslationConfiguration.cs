using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAction.Data.Entities;
using System;

namespace ShopAction.Data.Configuration
{
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("ProductTranslations");
            builder.HasOne(x => x.Product).WithMany(p => p.ProductTranslations).HasForeignKey(p => p.ProductId);
            builder.HasOne(x => x.Language).WithMany(x => x.ProductTranslations).HasForeignKey(x => x.LanguageId);
        }
    }
}
