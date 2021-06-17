using Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class PhotoSearch : PagedSearch
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int PhotoId { get; set; }
    }
}
