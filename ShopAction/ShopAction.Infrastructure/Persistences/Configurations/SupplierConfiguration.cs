using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAction.Domain.Entities;

namespace ShopAction.Infrastructure.Persistences.Configurations
{
    public class SupplierConfiguration: AppEntityTypeBaseConfiguration<Supplier>
    {
        public override void Configure(EntityTypeBuilder<Supplier> builder)
        {
            base.Configure(builder);
            builder.ToTable("Suppliers");
            builder.Property(x => x.ContactName).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
        }
    }
}
