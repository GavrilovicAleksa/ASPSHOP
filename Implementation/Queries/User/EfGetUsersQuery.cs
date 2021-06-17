using Application.DataTransfer;
using Application.DataTransfer.User;
using Application.Queries;
using Application.Queries.User;
using Application.Searches;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.User
{
    public class EfGetUsersQuery : IGetUsersQuery
    {
        private readonly Context _context;

        public EfGetUsersQuery(Context context)
        {
            this._context = context;
        }

        public int Id => 4;

        public string Name => "User Search";

        public PagedResponse<GetUserDto> Execute(UserSearch search)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.UserName.ToLower().Contains(search.Name.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            //Page == 1 
            var reponse = new PagedResponse<GetUserDto>
            {
                Page = search.Page,
                PerPage = search.PerPage,
                Count = query.Count(),
                Data = query.Skip(skipCount).Take(search.PerPage).Select(x => new GetUserDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Email = x.Email,
                    Addresses = x.Addresses
                }).ToList()
            };

            return reponse;
        }
    }
}
