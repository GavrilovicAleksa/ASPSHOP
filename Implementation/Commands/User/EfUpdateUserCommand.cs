using Application.DataTransfer.User;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.User
{
    public class EfUpdateUserCommand
    {
        public int Id => 4;

        public string Name => "User Update";

        private readonly Context _context;
      
        public EfUpdateUserCommand(Context context)
        {
            _context = context;
           
        }

        public void Execute(UserDto request)
        {
            var user = _context.Users.Find(request.Id);

            if (user != null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.Brand));
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.UserName = request.UserName;
            user.Password = request.Password;
            user.Email = request.Email;
            user.UpdatedAt = new DateTime();

            _context.SaveChanges();
        }
    }
}
