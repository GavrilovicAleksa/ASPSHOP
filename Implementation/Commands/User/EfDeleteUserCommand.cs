using Application.Commands.User;
using Application.DataTransfer;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.User
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        public int Id => 5;

        public string Name => "Deletes the user";

        private readonly Context _context;

        public EfDeleteUserCommand(Context context)
        {
            _context = context;

        }

        public void Execute(DeleteUserDto request)
        {
            var user = _context.Users.Find(request.Id);

            if (user != null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.User));
            }

            if (request.Hard == false) 
            {
                user.DeletedAt = new DateTime();
            } 
            else
            {
                _context.Users.Remove(user);
            }

            _context.SaveChanges();
        }
    }
}
