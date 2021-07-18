using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAction.Domain.Entities;

namespace ShopAction.Infrastructure.Persistences.Configurations
{
    public class CustomerConfiguration : AppEntityTypeBaseConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
            builder.ToTable("Customers");
            builder.Property(x => x.Emal).IsRequired();
            builder.Property(x => x.Region).IsRequired();
            builder.Property(x => x.Telephone).IsRequired();
        }
    }
}
