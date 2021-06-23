using Application.DataTransfer.BrandDataTransfer;
using Application.DataTransfer.Order;
using Application.Queries;
using Application.Queries.Cart;
using Application.Queries.Order;
using Application.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Order
{
    public class EfGetOrderQuery : IGetOrderQuery
    {
        private readonly Context _context;

        public EfGetOrderQuery(Context context)
        {
            this._context = context;
        }

        public int Id => 18;

        public string Name => "Brand Search";

        public PagedResponse<GetOrderDto> Execute(OrderSearch search)
        {
            var query = _context.Orders.AsQueryable();

            if (search.UserId == null)
            {
                query = query.Where(x => x.UserId.Equals(search.UserId));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var reponse = new PagedResponse<GetOrderDto>
            {
                Page = search.Page,
                PerPage = search.PerPage,
                Count = query.Count(),
                Data = query.Skip(skipCount).Take(search.PerPage).Select(x => new GetOrderDto
                {
                    DeliveredAt = x.DeliveredAt.ToString(),
                    PlacedAt = x.PlacedAt.ToString(),
                    Products = x.ProductOrders.Select(x => x.Product),
                }).ToList()
            };

            return reponse;
        }
    }
}
