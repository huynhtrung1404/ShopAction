using System.Linq;

namespace ShopAction.Application.Features.Permissions;

public class PermissionService(IRepository<Permission, Guid> permissionRepository, IUnitOfWork unitOfWork) : IPermissionService
{
    private readonly IRepository<Permission, Guid> _permissionRepository = permissionRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public Task<bool> AddPermissionAsync(AddPermissionRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeletePermissionAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<PermissionDetail> GetPermissionDetail(Guid id, CancellationToken cancellationToken)
    {
        var result = await _permissionRepository.FindByIdAsync(id, cancellationToken);
        return new(result.Id,
            result.Code,
            result.Description,
            result.Module,
            result.CreatedDate, result.LastModified, result.CreatedBy, result.LastModifiedBy);
    }

    public async Task<PagedResult<PermissionDetail>> GetPermissionsAsync(GetPermissionsRequest request, CancellationToken cancellationToken)
    {
        var data = await _permissionRepository.GetAllAsync(new PermissionSpecification(request), cancellationToken);
        var result = data.Select(x
            => new PermissionDetail(x.Id, x.Code, x.Description, x.Module, x.CreatedDate, x.LastModified, x.CreatedBy, x.LastModifiedBy));
        var count = await _permissionRepository.CountAllAsync(new PermissionSpecification(request), cancellationToken);
        return new([.. result], count, request.PageNumber, request.PageSize);
    }

    public Task<bool> UpdatePermissionAsync(UpdatePermissionRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}