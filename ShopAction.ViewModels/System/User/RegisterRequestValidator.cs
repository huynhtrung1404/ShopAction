﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAction.ViewModels.System.User
{
    public class RegisterRequestValidator: AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required")
                .MaximumLength(200).WithMessage("First name can not over 200 characters");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required")
                .MaximumLength(200).WithMessage("Last name cannot over 200 characters");
            RuleFor(x => x).NotNull().WithMessage("Object cannot be null");
            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday cannot greater than 100 years");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is not empty")
                .Matches(@"/^(?=.*\d)(?=.*[a - z])(?=.*[A - Z])(?=.*[a - zA - Z]).{ 6,}$")
                .WithMessage("Password should have digit numeric");
            RuleFor(x => x).Custom((request, context) =>
            {
                if (!request.Password.Equals(request.ConfirmPassword))
                {
                    context.AddFailure("Confirm password is not match");
                }
            });
        }
    }
}
