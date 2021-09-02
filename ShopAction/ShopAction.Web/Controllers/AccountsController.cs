using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAction.Application.Dtos;
using ShopAction.Application.Features.Users.Commands;
using ShopAction.Web.Commons;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopAction.Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : BaseController
    {
        public AccountsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterAccountDto register)
        {
            return Ok(await _mediator.Send(new RegisterUser(register)));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto login)
        {
            return Ok(await _mediator.Send(new LoginAccount(login)));
        }
    }
}
