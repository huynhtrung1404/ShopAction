using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAction.Domain.Entities.Base;

namespace ShopAction.Infrastructure.Persistences.Configurations
{
    public class AppEntityTypeBaseConfiguration<T> : IEntityTypeConfiguration<T> where T:BaseEntity
    {

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
        }
    }
}
