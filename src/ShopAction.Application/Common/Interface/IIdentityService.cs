using System.Threading.Tasks;
using ShopAction.Application.Models;

namespace ShopAction.Application.Common.Interface
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
        Task<Result> DeleteUserAsync(string userId);
        
    }
}