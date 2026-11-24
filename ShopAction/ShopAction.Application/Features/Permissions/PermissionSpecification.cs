using System.Linq.Expressions;
using System.Security.Cryptography;
using ShopAction.Application.Specifications;

namespace ShopAction.Application.Features.Permissions;

public class PermissionSpecification : BaseSpecification<Permission>
{
    public PermissionSpecification(GetPermissionsRequest request) : base(x => true)
    {
        ApplyPaging(request.PageNumber, request.PageSize);
        ApplyOrderByDescending(x => x.CreatedDate);
    }

}