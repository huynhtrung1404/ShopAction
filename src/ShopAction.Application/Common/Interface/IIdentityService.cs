using System.Threading.Tasks;
using ShopAction.Application.Features.UserManager.Commands;
using ShopAction.Application.Models;

namespace ShopAction.Application.Common.Interface
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
        Task<(Result Result, string UserId)> CreateUserAsync(RegistrationUser user);
        Task<Result> DeleteUserAsync(string userId);

    }
}