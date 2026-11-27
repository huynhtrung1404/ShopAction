namespace ShopAction.Frontend.Models;

public sealed class DashboardViewModel
{
    public int TotalUsers { get; init; }

    public int ActiveUsers { get; init; }

    public int TotalRoles { get; init; }

    public int TotalPermissions { get; init; }

    public int TotalPolicies { get; init; }

    public IReadOnlyList<DashboardActivityViewModel> Activities
    { get; init; } = [];
}

public sealed class DashboardActivityViewModel
{
    public string UserName { get; init; } = string.Empty;

    public string Action { get; init; } = string.Empty;

    public string Resource { get; init; } = string.Empty;

    public DateTime CreatedAt { get; init; }

    public string Status { get; init; } = string.Empty;
}