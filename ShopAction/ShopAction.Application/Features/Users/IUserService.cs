using System.Collections.Generic;

namespace ShopAction.Application.Features.Users;

public interface IUserService
{
    Task<UserDetail> GetUserById(Guid id, CancellationToken cancellationToken);

    Task<UserResult> GetListUserAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);

    Task<bool> AddUserAsync(AddUserRequest request, CancellationToken cancellationToken);

    Task<bool> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken);

    Task<bool> DeleteUserAsync(Guid Id, CancellationToken cancellationToken);

    Task<bool> ChangedPasswordAsync(ChangedPasswordRequest request, CancellationToken cancellationToken);
}