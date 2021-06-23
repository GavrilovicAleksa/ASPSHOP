using Application.DataTransfer.Order;
using Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class OrderSearch : PagedResponse<GetOrderDto>
    {
        public int UserId { get; set; }
    }
}
