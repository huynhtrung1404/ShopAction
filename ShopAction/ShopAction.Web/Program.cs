using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShopAction.Application.Common.Interface;
using ShopAction.Infrastructure;
using ShopAction.Web.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLogging();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddHostedService<MigrationHostedService>();

var app = builder.Build();


app.Run();
