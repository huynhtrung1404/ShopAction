using System;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ShopAction.Application.Features.Users;

namespace ShopAction.Web.Endpoints;

public static class UserEndpoint
{
    public static IEndpointRouteBuilder MapUserEndpoint(this IEndpointRouteBuilder endpoint)
    {
        var result = endpoint.MapGroup("/users").WithTags("User");

        result.MapGet("/", async ([FromQuery] int pageSize, [FromQuery] int pageNumber, [FromServices] IUserService userService, CancellationToken token) =>
        {
            var result = await userService.GetListUserAsync(pageSize, pageNumber, token);
            return Results.Ok(result);
        }).WithName("Get list of user");

        result.MapGet("/{id}/detail", async ([FromRoute] Guid id, IUserService userService, CancellationToken cancellationToken) =>
        {
            var result = await userService.GetUserById(id, cancellationToken);
            return Results.Ok(result);
        });

        result.MapPost("/add", async ([FromBody] AddUserRequest request, [FromServices] IUserService userService, CancellationToken cancellationToken) =>
        {
            var result = await userService.AddUserAsync(request, cancellationToken);
            return Results.Ok(result);
        });

        result.MapPut("/edit", async ([FromBody] UpdateUserRequest request, [FromServices] IUserService userService, CancellationToken cancellationToken) =>
        {
            var result = await userService.UpdateUserAsync(request, cancellationToken);
            return Results.Ok(result);
        });

        result.MapDelete("/delete/{id}", async ([FromRoute] Guid id, [FromServices] IUserService userService, CancellationToken cancellationToken) =>
        {
            var result = await userService.DeleteUserAsync(id, cancellationToken);
            return Results.Ok(result);
        });

        result.MapPut("/changePassword", async (ChangedPasswordRequest request, IUserService userService, CancellationToken cancellationToken) =>
        {
            var result = await userService.ChangedPasswordAsync(request, cancellationToken);
            return Results.Ok(result);
        });

        return result;
    }
}