using Application.DataTransfer.User;
using Application.Exceptions;
using Application.Queries;
using Application.Queries.User;
using Application.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.User
{
    public class EfGetSingleUserQuery : IGetSingleUserQuery
    {
        private readonly Context _context;

        public EfGetSingleUserQuery(Context context)
        {
            this._context = context;
        }
        public int Id => 2;

        public string Name => "Finds User";

        public SingleResponse<GetUserDto> Execute(UserSearch search)
        {
            var user = _context.Users.Find(search.Id);

            if(user == null)
            {
                throw new EntityNotFoundException(search.Id, typeof(Domain.User));
            }

            var response = new SingleResponse<GetUserDto>
            {
                Data = new GetUserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                    Addresses = user.Addresses
                }
            };

            return response;
            
        }
    }
}
