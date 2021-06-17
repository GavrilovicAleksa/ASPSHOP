using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class UserSearch : PagedSearch
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
