using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CartItem : Entity
    {
        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int CartId { get; set; }

        public Product Product { get; set; }

        public Cart Cart { get; set; }
    }
}
