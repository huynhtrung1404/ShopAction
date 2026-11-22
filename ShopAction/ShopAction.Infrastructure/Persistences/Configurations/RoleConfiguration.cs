using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopAction.Infrastructure.Persistences.Configurations;

public class RoleConfiguration : AppEntityTypeBaseConfiguration<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);
        builder.ToTable("Roles", "user");
    }
}