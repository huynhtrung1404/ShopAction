using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAction.Domain.Entities.Users;
using ShopAction.Infrastructure.Persistence.Configurations;

namespace ShopAction.Infrastructure.Persistences.Configurations;

public class UserConfiguration : AppEntityTypeBaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.ToTable("Users", "user");
        builder.HasIndex(x => x.UserName).IsUnique();
        builder.HasIndex(x => x.Password);
    }
}