using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAction.Application.Features.UserManager.Commands;
using ShopAction.Web.Controllers.Base;

namespace ShopAction.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUserController : BaseController
    {
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationUser user)
        {
            return Ok(await Mediator.Send(user));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(SignInUserManager user)
        {
            return Ok(await Mediator.Send(user));
        }
    }
}