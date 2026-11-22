using System.Collections.Generic;

namespace ShopAction.Domain.Entities.Users;

public class Role : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsSystemRole { get; set; }

    public ICollection<UserRole>? UserRoles { get; set; }
    public ICollection<RolePermission>? RolePermissions { get; set; }
}