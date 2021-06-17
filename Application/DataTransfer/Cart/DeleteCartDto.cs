using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer.CartDataTransfer
{
    public class DeleteCartDto
    {
        public int CartId { get; set; }

        public int CartItemId { get; set; }
    }
}
