using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopAction.Infrastructure.Persistences.Configurations;

public class PermissionConfiguration : AppEntityTypeBaseConfiguration<Permission>
{
    public override void Configure(EntityTypeBuilder<Permission> builder)
    {
        base.Configure(builder);
        builder.ToTable("Permissions", "user");
    }
}