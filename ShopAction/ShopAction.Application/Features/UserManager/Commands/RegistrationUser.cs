using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopAction.Application.Common.Interface;

namespace ShopAction.Application.Features.UserManager.Commands
{
    public class RegistrationUser : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class RegistrationUserHandler : IRequestHandler<RegistrationUser, bool>
    {
        private readonly IIdentityService identityService;
        public RegistrationUserHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }
        public async Task<bool> Handle(RegistrationUser request, CancellationToken cancellationToken)
        {
            var result = await identityService.CreateUserAsync(request);
            return result.Result.Succeeded;
        }
    }
}
