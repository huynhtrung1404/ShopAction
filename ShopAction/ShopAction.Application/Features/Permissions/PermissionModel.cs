namespace ShopAction.Application.Features.Permissions;

public record PermissionDetail(Guid Id,
    string Code,
    string Description,
    string Module,
    DateTimeOffset CreatedDate,
    DateTimeOffset? UpdatedDate,
    string CreatedBy,
    string UpdatedBy);

public record struct GetPermissionsRequest(int PageSize, int PageNumber);
public record struct SearchPermissionsRequest(int PageSize, int PageNumber, string SearchKeyword);
public record AddPermissionRequest(string Code, string Description, string Module);
public record UpdatePermissionRequest(Guid Id, string Code, string Description, string Module);
