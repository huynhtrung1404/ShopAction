namespace ShopAction.Domain.Entities.Users;

public class RolePermission : BaseEntity
{
    public Guid RoleId { get; set; }
    public Role? Role { get; set; }
    public Permission? Permission { get; set; }
    public Guid PermissionId { get; set; }
}