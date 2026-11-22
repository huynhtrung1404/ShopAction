using System.Linq;
using System.Net;
using ShopAction.Domain.Entities.Users;
using ShopAction.Domain.Interfaces;

namespace ShopAction.Application.Features.Users;

public class UserService(IRepository<User, Guid> user, IUnitOfWork unitOfWork) : IUserService
{
    private readonly IRepository<User, Guid> _user = user;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<UserResult> GetListUserAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var data = await _user.GetAllAsync(new UserSpecification(pageSize, pageNumber), cancellationToken);
        var totalPage = await _user.CountAllAsync(new UserSpecification(pageSize, pageNumber), cancellationToken);
        var result = data.Select(x => new UserDetail(x.UserName, x.Email, x.Password, x.IsActive));
        return new UserResult(result, totalPage, pageSize, pageNumber);
    }

    public async Task<UserDetail> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        var data = await _user.FindByIdAsync(id);
        return new UserDetail(data.UserName, data.Email, data.Password, data.IsActive);
    }
}