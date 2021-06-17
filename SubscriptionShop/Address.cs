using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Address : Entity
    {
        public string Street { get; set; }

        public int ZipCode { get; set; }
        public User User { get; set; }

        public int UserId { get; set; }
    }
}
