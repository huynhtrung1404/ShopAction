﻿using System;
namespace ShopAction.Application.Dtos
{
    public class RegisterAccountDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
