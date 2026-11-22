using System;

namespace ShopAction.Domain.Entities.Users;

public class UserRole : BaseEntity
{
    public Role? Role { get; set; }
    public User? User { get; set; }
    public Guid RoleId { get; set; }
    public Guid UserId { get; set; }
}