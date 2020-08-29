using ShopAction.ViewModels.System.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopAction.ApplicationService.System.Users
{
    public interface IUserService
    {
        Task<bool> Authenticate(LoginRequest request);
        Task<bool> register(RegisterRequest request);
    }
}
