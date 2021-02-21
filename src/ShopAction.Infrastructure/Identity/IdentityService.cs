using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IConfiguration config;
        public IdentityService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IConfiguration config)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.config = config;
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
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(string userName, string password, bool isRemember)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new NotFoundException("User is not existing");
            }
            var result = await signInManager.PasswordSignInAsync(user, password, isRemember, false);
            if (!result.Succeeded)
            {
                throw new NotFoundException("Wrong password, please try again");
            }
            var claims = await userManager.GetClaimsAsync(user);
            if (claims.Count() < 1)
            {
                claims.Add(new Claim("userId", user.Id.ToString()));
                claims.Add(new Claim("firstName", user.FirstName));
                claims.Add(new Claim("lastName", user.LastName));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["Tokens:Issuer"],
                config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}