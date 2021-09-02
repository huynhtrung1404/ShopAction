using System;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ShopAction.Application.Common.Interface;
using ShopAction.CrossCutting.Constants;
using ShopAction.Domain.Interfaces;
using ShopAction.Infrastructure.Persistences;
using ShopAction.Infrastructure.Persistences.Repositories;
using ShopAction.Infrastructure.Services;

namespace ShopAction.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var migrationsAssembly = typeof(DependencyInjection).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString(AppConstant.ConnectionString)));
            services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            services.AddIdentityServer()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(configuration.GetConnectionString(AppConstant.ConnectionString), sql => sql.MigrationsAssembly(migrationsAssembly));
                }).AddOperationalStore(options => {
                    options.ConfigureDbContext = b => b.UseSqlServer(configuration.GetConnectionString(AppConstant.ConnectionString), sql => sql.MigrationsAssembly(migrationsAssembly));
                }).AddAspNetIdentity<IdentityUser<Guid>>();
            services.AddTransient<IUserService, UserService>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration.GetValue<string>(AppConstant.Audience),
                    ValidIssuer = configuration.GetValue<string>(AppConstant.Issuer),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>(AppConstant.TokenKey)))
                };
            }); ;
            return services;
        }
    }
}