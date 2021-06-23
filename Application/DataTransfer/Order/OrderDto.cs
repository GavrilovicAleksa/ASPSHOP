using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransfer.Order
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string PlacedAt { get; set; }
        public string DeliveredAt { get; set; }

        public int UserId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public int? ZipCode { get; set; }

        public string Country { get; set; }
        public virtual ICollection<int> Products { get; set; }
    }
}
