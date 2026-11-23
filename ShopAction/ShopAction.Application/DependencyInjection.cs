using Microsoft.Extensions.DependencyInjection;
using ShopAction.Application.Features.Permissions;
using ShopAction.Application.Features.Users;

namespace ShopAction.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPermissionService, PermissionService>();
            return services;
        }
    }
}