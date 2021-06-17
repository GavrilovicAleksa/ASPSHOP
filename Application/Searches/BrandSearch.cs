using Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class BrandSearch : PagedSearch
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
