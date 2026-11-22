using System.Collections.Generic;

namespace ShopAction.Application.Features.Users;

public interface IUserService
{
    Task<UserDetail> GetUserById(Guid id, CancellationToken cancellationToken);

    Task<UserResult> GetListUserAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);
}