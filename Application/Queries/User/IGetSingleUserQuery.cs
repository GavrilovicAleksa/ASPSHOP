using Application.DataTransfer.User;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.User
{
    public interface IGetSingleUserQuery : IQuery<UserSearch, SingleResponse<GetUserDto>>
    {
    }
}
