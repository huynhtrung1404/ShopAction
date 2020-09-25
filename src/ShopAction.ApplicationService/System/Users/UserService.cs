using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopAction.Data.Entities;
using ShopAction.Utilities.Exceptions;
using ShopAction.ViewModels.System.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

        public async Task<bool> AddRole(RoleRequest request)
        {
            var role = await roleManager.FindByNameAsync(request.Name);
            if (role != null)
            {
                throw new ShopActionException("Role is existing and cannot add");
            }
            var appRole = new AppRole
            {
                Name = request.Name,
                Description = request.Description,
            };
            var result = await roleManager.CreateAsync(appRole);
            return result.Succeeded;
        }

        public async Task<string> Authenticate(LoginRequest request)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return null;
            }
            var result = await signInManager.PasswordSignInAsync(user, request.Password, request.IsRemenber, true);
            if (!result.Succeeded) {
                return null;
            }
            var roles = await userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["Tokens:Issuer"],
                config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<List<RoleViewModel>> GetAllRoleAsync()
        {
            var result = await roleManager.Roles.Select(x => new RoleViewModel
            {
                Description = x.Description,
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return result;
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new AppUser()
            {
                Dob = request.Dob,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, request.Password);
            var role = await roleManager.FindByNameAsync("admin");
            if (role == null)
            {
                role = new AppRole
                {
                    Name = "admin",
                    Id = new Guid(),
                    Description = "Admin"
                };
                var userRole =  await roleManager.CreateAsync(role);
                if (!userRole.Succeeded)
                {
                    throw new ShopActionException("Don't find this role to register user");
                }
            }
            await userManager.AddToRoleAsync(user, role.Name);
            return result.Succeeded;
        }
    }
}
