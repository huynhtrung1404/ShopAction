using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAction.Domain.Entities;

namespace ShopAction.Infrastructure.Persistences.Configurations
{
    public class OrderConfiguration : AppEntityTypeBaseConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);
            builder.ToTable("Orders");
            builder.Property(x => x.ShipAddress).IsRequired();
            builder.Property(x => x.ShipPhoneNumber).IsRequired();
            builder.Property(x => x.ShipEmail).IsRequired().HasMaxLength(255);
        }
    }
}
