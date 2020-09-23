﻿using FluentValidation;

namespace ShopAction.ViewModels.System.User
{
    public class RoleRequestValidator: AbstractValidator<RoleRequest>
    {
        public RoleRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Role name cannot be Empty");
            RuleFor(x => x.Description).NotNull().WithMessage("Description cannot be null");
        }
    }
}