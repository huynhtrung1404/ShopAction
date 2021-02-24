using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Common.Repositories;

namespace ShopAction.Application {
    public static class DependencyInjection {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}