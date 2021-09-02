using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ShopAction.Application.Common.Interface;
using ShopAction.Application.Dtos;

namespace ShopAction.Application.Features.Users.Commands
{
    public class LoginAccount: IRequest<string>
    {
       public UserLoginDto Account { get; set; }

        public LoginAccount(UserLoginDto account)
        {
            Account = account;
        }
    }

    public class LoginAccountHandler : IRequestHandler<LoginAccount, string>
    {
        private readonly IUserService _userService;

        public LoginAccountHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> Handle(LoginAccount request, CancellationToken cancellationToken)
        {
            return await _userService.SignInAsync(request.Account);
        }
    }
}
