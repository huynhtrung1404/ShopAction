using Microsoft.AspNetCore.Http.HttpResults;
using ShopAction.Application.Features.Permissions;

namespace ShopAction.Web.Endpoints;

public static class PermissionEndpoint
{
    public static IEndpointRouteBuilder MapPermissionEndpoint(this IEndpointRouteBuilder builder)
    {
        var result = builder.MapGroup("/permission").WithTags("Permission").WithDescription("Manage permission");

        result.MapGet("/all", async ([AsParameters] GetPermissionsRequest request,
            [FromServices] IPermissionService permissionService,
            CancellationToken cancellationToken) =>
        {
            var data = await permissionService.GetPermissionsAsync(request, cancellationToken);
            return Results.Ok(data);
        });

        result.MapGet("/{id}/detail", async ([FromRoute] Guid id,
            [FromServices] IPermissionService permissionService,
            CancellationToken cancellationToken) =>
        {
            var result = await permissionService.GetPermissionDetail(id, cancellationToken);
            return Results.Ok(result);
        });

        result.MapPost("/add", async ([FromBody] AddPermissionRequest request, [FromServices] IPermissionService permissionService, CancellationToken cancellationToken) =>
        {
            var result = await permissionService.AddPermissionAsync(request, cancellationToken);
            return Results.Ok(result);
        });

        result.MapPut("/update", async ([FromBody] UpdatePermissionRequest request, [FromServices] IPermissionService permissionService, CancellationToken cancellationToken) =>
        {
            var result = await permissionService.UpdatePermissionAsync(request, cancellationToken);
            return Results.Ok(result);
        });

        result.MapDelete("/{id}/delete", async ([FromRoute] Guid id, [FromBody] IPermissionService permissionService, CancellationToken cancellationToken) =>
        {
            var result = await permissionService.DeletePermissionAsync(id, cancellationToken);
            return Results.Ok(result);
        });

        return result;
    }
}