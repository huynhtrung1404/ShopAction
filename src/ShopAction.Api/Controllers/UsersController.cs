using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAction.ApplicationService.System.Users;
using ShopAction.Data.Ef;
using ShopAction.ViewModels.System.User;

namespace ShopAction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService, ApplicationDbContext context)
        {
            this.userService = userService;
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is incorrect type");
            }
            var result = await userService.Authenticate(request);
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("User or password is incorrect");
            }
            return Ok(new { token = result });
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is incorrect type");
            }
            var result = await userService.Register(request);
            return Ok(result);
        }

        [HttpGet("GetAllRole")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllRole()
        {
            var result = await userService.GetAllRoleAsync();
            return Ok(result);
        }

        [HttpGet("AddRole")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddNewRole(RoleRequest request)
        {
            var result = await userService.AddRole(request);
            return Ok(result);
        }
    }
}
