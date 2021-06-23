using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer.Order
{
    public class GetOrderDto
    {
        public string PlacedAt { get; set; }
        public string DeliveredAt { get; set; }
        public Address Address { get; set; }
        public virtual IEnumerable<Domain.Product> Products { get; set; } = new HashSet<Domain.Product>();
    }
}
