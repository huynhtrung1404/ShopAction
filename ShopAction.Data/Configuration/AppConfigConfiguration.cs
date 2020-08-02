using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAction.Data.Entities;

namespace ShopAction.Data.Configuration
{
    public class AppConfigConfiguration : IEntityTypeConfiguration<AppConfig>
    {
        public void Configure(EntityTypeBuilder<AppConfig> builder)
        {
            builder.ToTable("AppConfig");
            builder.HasKey(x => x.Key);
            builder.Property(x => x.Value).IsRequired(true);
        }
    }
}
