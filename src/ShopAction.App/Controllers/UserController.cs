using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopAction.ApplicationService.System.Users;
using ShopAction.ViewModels.System.User;

namespace ShopAction.App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var result = await userService.Register(user);
            return RedirectToAction("Index", "Home");
        }
    }
}
