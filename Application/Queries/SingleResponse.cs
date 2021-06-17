using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class SingleResponse<T> where T : class
    {
        public T Data { get; set; }
    }
}
