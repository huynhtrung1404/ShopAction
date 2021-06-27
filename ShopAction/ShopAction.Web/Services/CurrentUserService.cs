using System;
using ShopAction.Application.Common.Interface;

namespace ShopAction.Web.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public Guid UserId { get; set; }
    }
}
