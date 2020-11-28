using Microsoft.AspNetCore.Identity;
using ShopAction.Application.Models;
using System.Linq;

namespace ShopAction.Infrastructure.Identity
{
    public static class IdentityResultExtension
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded ? Result.Success() : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}