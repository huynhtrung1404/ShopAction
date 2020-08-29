using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopAction.Data.Entities;
using ShopAction.Utilities.Exceptions;
using ShopAction.ViewModels.System.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopAction.ApplicationService.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IConfiguration config;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IConfiguration config)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.config = config;
        }
        public async Task<bool> Authenticate(LoginRequest request)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return false;
            }
            var result = await signInManager.PasswordSignInAsync(user, request.Password, request.IsRemenber, true);
            if (result.Succeeded) {
                return false;
            }
            var roles = await userManager.GetRolesAsync(user);
            var claim = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""));

        }

        public Task<bool> register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
