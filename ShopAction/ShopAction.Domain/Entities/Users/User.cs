using System.Collections.Generic;

namespace ShopAction.Domain.Entities.Users;

public class User : BaseEntity
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public bool IsActive { get; set; }

    public ICollection<UserRole>? UserRoles { get; set; }
    public ICollection<UserPermission>? UserPermissions { get; set; }
}