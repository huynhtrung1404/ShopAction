using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShopAction.Infrastructure.Persistence;

namespace ShopAction.Web.Services;

public class MigrationHostedService(IServiceScopeFactory serviceScopeFactory, ILogger<MigrationHostedService> logger) : IHostedService
{
    private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;
    private readonly ILogger<MigrationHostedService> _logger = logger;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Migration is running");
        using var scoped = _serviceScopeFactory.CreateScope();
        var dbContext = scoped.ServiceProvider.GetRequiredService<AppDbContext>();
        await dbContext.Database.MigrateAsync(cancellationToken);
        _logger.LogInformation("Migration Completed");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}