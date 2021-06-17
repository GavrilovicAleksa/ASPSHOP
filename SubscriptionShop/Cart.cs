using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cart : Entity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<CartItem> CartItem { get; set; } = new HashSet<CartItem>();
    }
}
