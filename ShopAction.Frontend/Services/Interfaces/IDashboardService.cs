using ShopAction.Frontend.Models;

namespace ShopAction.Frontend.Services.Interfaces;

public interface IDashboardService
{
    Task<DashboardViewModel> GetDashboardAsync();
}