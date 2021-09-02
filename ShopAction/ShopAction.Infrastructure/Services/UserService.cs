using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Dtos;
using ShopAction.CrossCutting.Constants;

namespace ShopAction.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IConfiguration _config;

        public UserService(UserManager<IdentityUser<Guid>> userManager, RoleManager<IdentityRole<Guid>> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<bool> RegisterAsync(RegisterAccountDto registerAccount)
        {
            var userName = await _userManager.FindByNameAsync(registerAccount.UserName);
            if (userName != null)
            {
                return false;
            }

            var identityUser = new IdentityUser<Guid>
            {
                Email = registerAccount.Email,
                UserName = registerAccount.UserName,
                PhoneNumber = registerAccount.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(identityUser, registerAccount.Password);
            return result.Succeeded;
        }

        public async Task<string> SignInAsync(UserLoginDto user)
        {
            var userName = await _userManager.FindByNameAsync(user.UserName);
            var signInResult = await _userManager.CheckPasswordAsync(userName, user.Password);
            if (!signInResult)
            {
                throw new Exception("User is not existing");
            }
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>(AppConstant.TokenKey)));
            var token = new JwtSecurityToken(
                 issuer: _config.GetValue<string>(AppConstant.Issuer),
                 audience: _config.GetValue<string>(AppConstant.Audience),
                 expires: DateTime.Now.AddHours(24),
                 claims: claims,
                 signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
