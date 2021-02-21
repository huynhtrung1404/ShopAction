using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopAction.Application.Common.Interface;

namespace ShopAction.Application.Features.UserManager.Commands
{
    public class SignInUserManager : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }

    public class SignInUserManagerHandler : IRequestHandler<SignInUserManager, string>
    {
        private readonly IIdentityService identityService;
        public SignInUserManagerHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }
        public async Task<string> Handle(SignInUserManager request, CancellationToken cancellationToken)
        {
            return await identityService.Login(request.UserName, request.Password, request.IsRemember);
        }
    }
}
