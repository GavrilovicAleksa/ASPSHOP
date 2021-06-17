using Application.DataTransfer.Product;
using Application.Exceptions;
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
    public class EfGetSingleProductQuery : IGetSingleProductQuery
    {
        private readonly Context _context;

        public EfGetSingleProductQuery(Context context)
        {
            this._context = context;
        }
        public int Id => 2;

        public string Name => "Find a Product by Id";

        public SingleResponse<GetProductDto> Execute(ProductSearch search)
        {
            var product = _context.Products.Find(search.Id);

            if (product == null)
            {
                throw new EntityNotFoundException(search.Id, typeof(Domain.User));
            }

            var response = new SingleResponse<GetProductDto>
            {
                Data = new GetProductDto
                {
                    Name = product.Name,
                    Price = product.Price,
                    Photos = product.Photo,
                    Brand = product.Brand,
                    Category = product.ProductCategory.Select(x => x.Category)
                }
            };

            return response;

        }
    }
}
