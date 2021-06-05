using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAction.Application.Features.UserManager.Commands;
using ShopAction.Web.Controllers.Base;

namespace ShopAction.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUserController : BaseController
    {
        public ManageUserController(IMediator mediator): base(mediator)
        {

        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationUser user)
        {
            return Ok(await _mediator.Send(user));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(SignInUserManager user)
        {
            return Ok(await _mediator.Send(user));
        }
    }
}