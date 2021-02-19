using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ShopAction.Application.Common.Exceptions;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Features.UserManager.Commands;
using ShopAction.Application.Models;
using ShopAction.Infrastructure.Identity.Models;

namespace ShopAction.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        public IdentityService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public async Task<(Result Result, string UserId)> CreateUserAsync(RegistrationUser user)
        {
            var existingEmail = await userManager.FindByEmailAsync(user.Email);
            if (existingEmail != null)
            {
                throw new NotFoundException();
            }

            var userRegister = new AppUser
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB
            };

            var result = await userManager.CreateAsync(userRegister, user.Password);

            return (result.ToApplicationResult(), userRegister.Id.ToString());
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