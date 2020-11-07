using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.ViewModels.System.User
{
    public class LoginRequestValidator: AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(4).WithMessage("Password is as least 6 charactor");
        }
    }
}
