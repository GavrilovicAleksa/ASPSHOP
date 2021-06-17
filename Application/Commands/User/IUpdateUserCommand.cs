using Application.DataTransfer;
using Application.DataTransfer.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User
{
    public interface IUpdateUserCommand : ICommand<UserDto>
    {
    }
}
