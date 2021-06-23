using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer.CartDataTransfer
{
    public class GetCartDto
    {
        public int Id { get; set; }

        public Domain.User User { get; set; }

        public IEnumerable<Domain.Product> Products { get; set; }
    }
}
