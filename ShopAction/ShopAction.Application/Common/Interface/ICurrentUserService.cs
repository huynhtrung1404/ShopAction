using System;
namespace ShopAction.Application.Common.Interface
{
    public interface ICurrentUserService
    {
        Guid UserId { get; set; }
    }
}
