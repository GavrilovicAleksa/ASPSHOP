using Application.DataTransfer;
using Application.DataTransfer.User;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<UserDto>
    {
        
        public RegisterUserValidator(Context context)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(4)
                .Must(x => !context.Users.Any(user => user.UserName == x))
                .WithMessage("Username is already taken.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
