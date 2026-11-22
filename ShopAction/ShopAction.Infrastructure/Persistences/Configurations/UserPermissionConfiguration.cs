using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopAction.Infrastructure.Persistences.Configurations;

public class UserPermissionConfiguration : AppEntityTypeBaseConfiguration<UserPermission>
{
    public override void Configure(EntityTypeBuilder<UserPermission> builder)
    {
        base.Configure(builder);
        builder.ToTable("UserPermissions", "user");
    }
}