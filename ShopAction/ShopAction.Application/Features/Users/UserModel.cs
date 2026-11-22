namespace ShopAction.Application.Features.Users;

public record UserDetail(string UserName, string Email, string Password, bool IsActive);

public record UserResult(IEnumerable<UserDetail> Users, int TotalPage, int PageSize, int PageNumber);