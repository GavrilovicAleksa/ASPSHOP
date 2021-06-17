using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class PagedResponse<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public int NbPages { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
    }
}
