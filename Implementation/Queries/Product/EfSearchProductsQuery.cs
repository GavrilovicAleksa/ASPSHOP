using Application.DataTransfer.Product;
using Application.Queries;
using Application.Queries.Product;
using Application.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Product
{
    public class EfSearchProductsQuery : ISearchProductsQuery
    {
        private readonly Context _context;

        public EfSearchProductsQuery(Context context)
        {
            this._context = context;
        }

        public int Id => 18;

        public string Name => "Brand Search";

        public PagedResponse<GetProductDto> Execute(ProductSearch search)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var reponse = new PagedResponse<GetProductDto>
            {
                Page = search.Page,
                PerPage = search.PerPage,
                Count = query.Count(),
                Data = query.Skip(skipCount).Take(search.PerPage).Select(x => new GetProductDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    //Album = x.Album,
                    Brand = x.Brand,
                    //Category = x.Category
                }).ToList()
            };

            return reponse;
        }
    }
}
