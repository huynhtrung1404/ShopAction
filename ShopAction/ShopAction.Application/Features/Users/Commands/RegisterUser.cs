using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Dtos;

namespace ShopAction.Application.Features.Users.Commands
{
    public class RegisterUser : IRequest<bool>
    {
        public RegisterAccountDto RegisterAccount { get; set; }
        public RegisterUser(RegisterAccountDto registerAccount)
        {
            RegisterAccount = registerAccount;
        }
    }

    public class RegisterUserHandler : IRequestHandler<RegisterUser, bool>
    {
        private readonly IUserService _userService;

        public RegisterUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            return await _userService.RegisterAsync(request.RegisterAccount);
        }
    }
}
