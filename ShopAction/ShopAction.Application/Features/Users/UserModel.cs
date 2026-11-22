using System.ComponentModel.DataAnnotations;

namespace ShopAction.Application.Features.Users;

public record UserDetail(Guid Id, string UserName, string Email, string Password, bool IsActive, DateTimeOffset CreatedDate, DateTimeOffset? UpdatedDate);

public record UserResult(IEnumerable<UserDetail> Users, int TotalPage, int PageSize, int PageNumber);

public record AddUserRequest([Required] string UserName, [Required] string Email, [Required] string Password, bool IsActive);

public record UpdateUserRequest(Guid Id, string Email, bool IsActive);

public record ChangedPasswordRequest(string UserName, string OldPassword, string NewPassword);