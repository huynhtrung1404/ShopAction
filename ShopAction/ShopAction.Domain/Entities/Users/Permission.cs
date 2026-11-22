namespace ShopAction.Domain.Entities.Users;

public class Permission : BaseEntity
{
    /// <summary>
    /// this field will saving the permission. Example: users.read
    /// </summary>
    public string? Code { get; set; }
    public string? Description { get; set; }
    /// <summary>
    /// module can be access with permission. Example: Users, Roles
    /// </summary>
    public string? Module { get; set; }
}