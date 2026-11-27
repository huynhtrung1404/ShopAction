using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopAction.Application;
using ShopAction.Application.Common.Interface;
using ShopAction.Infrastructure;
using ShopAction.Web.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLogging();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddHostedService<MigrationHostedService>();
builder.Services.AddApplication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapUserEndpoint();
app.MapPermissionEndpoint();
app.Run();
