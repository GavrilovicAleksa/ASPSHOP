using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order : Entity 
    {
        public DateTime PlacedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }

        public Address Address { get; set; }

        public int AddressId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new HashSet<ProductOrder>();
    }
}
