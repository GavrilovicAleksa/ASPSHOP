using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer.User
{
    public class GetUserDto : BaseUserDto
    {
        public IEnumerable<Address> Addresses { get; set; } = new List<Address>();
    }
}
