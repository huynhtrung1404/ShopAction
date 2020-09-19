using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.ViewModels.System.User
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsRemenber { get; set; }
    }
}
