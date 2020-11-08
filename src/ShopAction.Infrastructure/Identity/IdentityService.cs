using System.Threading.Tasks;
using ShopAction.Application.IIdentityService;
using ShopAction.Application.Models;

namespace ShopAction.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        public Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> DeleteUserAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetUserNameAsync(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}