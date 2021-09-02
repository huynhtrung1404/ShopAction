using System;
namespace ShopAction.Application.Dtos
{
    public class UserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
