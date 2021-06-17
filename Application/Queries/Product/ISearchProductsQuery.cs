using Application.DataTransfer.Product;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Product
{
    public interface ISearchProductsQuery : IQuery<ProductSearch, PagedResponse<GetProductDto>>
    {
    }
}
