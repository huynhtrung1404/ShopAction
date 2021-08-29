using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopAction.CrossCutting.Constants;
using ShopAction.Domain.Interfaces;
using ShopAction.Infrastructure.Persistences;
using ShopAction.Infrastructure.Persistences.Repositories;

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
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(configuration.GetConnectionString(AppConstant.ConnectionString), sql => sql.MigrationsAssembly(migrationsAssembly));
                }).AddOperationalStore(options => {
                    options.ConfigureDbContext = b => b.UseSqlServer(configuration.GetConnectionString(AppConstant.ConnectionString), sql => sql.MigrationsAssembly(migrationsAssembly));
                });
            return services;
        }
    }
}