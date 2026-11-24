using System.Linq;
using System.Net;
using ShopAction.Application.Common.Helpers;
using ShopAction.Application.Common.Models;
using ShopAction.Domain.Entities.Users;
using ShopAction.Domain.Interfaces;

namespace ShopAction.Application.Features.Users;

public class UserService(IRepository<User, Guid> user, IUnitOfWork unitOfWork) : IUserService
{
    private readonly IRepository<User, Guid> _user = user;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<bool> AddUserAsync(AddUserRequest request, CancellationToken cancellationToken)
    {
        var user = new User()
        {
            Email = request.Email,
            UserName = request.UserName,
            Password = PasswordHelper.Hash(request.Password),
            IsActive = request.IsActive
        };

        await _user.AddAsync(user);
        await _unitOfWork.CommitChangesAsync();
        return true;
    }

    public async Task<bool> ChangedPasswordAsync(ChangedPasswordRequest request, CancellationToken cancellationToken)
    {
        var data = await _user.GetItemAsync(new UserSpecification(request.UserName), cancellationToken) ?? throw new ArgumentException("No username found");
        if (!PasswordHelper.Verify(request.OldPassword, data.Password))
        {
            throw new ArgumentException("Password is not correct");
        }

        data.Password = PasswordHelper.Hash(request.NewPassword);
        await _unitOfWork.CommitChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingData = await _user.FindByIdAsync(id, cancellationToken) ?? throw new Exception("No data found");
        _user.Delete(existingData);
        await _unitOfWork.CommitChangesAsync();
        return true;
    }

    public async Task<PagedResult<UserDetail>> GetListUserAsync(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var data = await _user.GetAllAsync(new UserSpecification(pageSize, pageNumber), cancellationToken);
        var totalItem = await _user.CountAllAsync(new UserSpecification(pageSize, pageNumber), cancellationToken);
        var result = data.Select(x => new UserDetail(x.Id, x.UserName, x.Email, x.Password, x.IsActive, x.CreatedDate, x.LastModified));
        var totalPage = pageSize == 0 ? 0 : (totalItem + pageSize - 1) / pageSize;

        return new([.. result], totalItem, pageNumber, pageSize);
    }

    public async Task<UserDetail> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        var data = await _user.FindByIdAsync(id);
        return new UserDetail(id, data.UserName, data.Email, data.Password, data.IsActive, data.CreatedDate, data.LastModified);
    }

    public async Task<bool> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var existingData = await _user.FindByIdAsync(request.Id) ?? throw new Exception("No data found");
        existingData.Email = request.Email;
        existingData.IsActive = request.IsActive;
        await _unitOfWork.CommitChangesAsync();
        return true;
    }
}