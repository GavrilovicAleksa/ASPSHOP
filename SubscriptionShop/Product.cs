using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Category_Id { get; set; }
       // public int Album_Id { get; set; }
        public int Brand_id { get; set; }
        public virtual ICollection<Photo> Photo { get; set; } = new HashSet<Photo>();
        public virtual ICollection<ProductCategory> ProductCategory { get; set; } = new HashSet<ProductCategory>();
        public virtual Brand Brand { get; set; }
    }
}
