using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopAction.Infrastructure.Persistences.Configurations;

public class RolePermissionConfiguration : AppEntityTypeBaseConfiguration<RolePermission>
{
    public override void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        base.Configure(builder);
        builder.ToTable("RolePermissions", "user");
    }
}