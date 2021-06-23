using Application.DataTransfer.BrandDataTransfer;
using Application.DataTransfer.CartDataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Cart
{
    public interface IGetCartQuery : IQuery<CartSearch, PagedResponse<GetCartDto>>
    {
    }
}
