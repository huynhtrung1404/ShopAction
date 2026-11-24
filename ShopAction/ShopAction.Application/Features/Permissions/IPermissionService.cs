namespace ShopAction.Application.Features.Permissions;

public interface IPermissionService
{
    Task<PagedResult<PermissionDetail>> GetPermissionsAsync(GetPermissionsRequest request, CancellationToken cancellationToken);
    Task<PermissionDetail> GetPermissionDetail(Guid id, CancellationToken cancellationToken);
    Task<bool> AddPermissionAsync(AddPermissionRequest request, CancellationToken cancellationToken);
    Task<bool> UpdatePermissionAsync(UpdatePermissionRequest request, CancellationToken cancellationToken);
    Task<bool> DeletePermissionAsync(Guid id, CancellationToken cancellationToken);
}