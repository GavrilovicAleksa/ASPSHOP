using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Brand : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Slogan { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

        public virtual User Manager { get; set; }
    }
}
