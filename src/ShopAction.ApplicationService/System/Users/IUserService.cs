using ShopAction.ViewModels.System.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopAction.ApplicationService.System.Users
{
    public interface IUserService
    {
        Task<string> Authenticate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
        Task<bool> AddRole(RoleRequest request);
        Task<List<RoleViewModel>> GetAllRoleAsync();
    }
}
