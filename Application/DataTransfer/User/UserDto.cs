using Application.DataTransfer.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer.User
{
    public class UserDto : BaseUserDto
    {
        public string Password { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public int? ZipCode { get; set; }

        public string Country { get; set; }
    }
}
