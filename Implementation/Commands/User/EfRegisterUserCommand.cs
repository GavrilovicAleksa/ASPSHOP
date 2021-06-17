using Application.Commands.User;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Implementation.Validators;
using Application.DataTransfer;
using Application.DataTransfer.User;
using FluentValidation;
using Domain;

namespace Implementation.Commands.User
{
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        public int Id => 4;

        public string Name => "User Registration";

        private readonly Context _context;
        private readonly RegisterUserValidator _validator;

        public EfRegisterUserCommand(Context context, RegisterUserValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = new Domain.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = request.Password,
                Email = request.Email,
            };

            if (request.Street != null && request.ZipCode != null)
            {
                user.Addresses.Add(
                     new Domain.Address
                     {
                         ZipCode = (int)request.ZipCode,
                         Street = request.Street
                     }
                 );
            }

            List<UserUseCase> collection = new List<UserUseCase>();

            collection.Add(new UserUseCase { UseCaseId = 4 });

            user.UserUserCases = collection;

            //user.UserUserCases.Add();

            _context.Users.Add(user);

            _context.SaveChanges();
        }
    }
}
