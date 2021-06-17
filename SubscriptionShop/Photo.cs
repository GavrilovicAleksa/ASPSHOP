using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Photo : Entity
    {
        public string url { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }
    }
}
