using Application;
using Application.DataTransfer.BrandDataTransfer;
using Application.Exceptions;
using Application.Queries;
using Application.Queries.Brand;
using Application.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Brand
{
    public class EfGetSingleBrandQuery : IGetSingleBrandQuery
    {
        private readonly Context _context;

        public EfGetSingleBrandQuery(Context context)
        {
            this._context = context;
        }
        public int Id => 2;

        public string Name => "Finds User";

        public SingleResponse<GetBrandDto> Execute(BrandSearch search)
        {
            var brand = _context.Brands.Find(search.Id);

            if (brand == null)
            {
                throw new EntityNotFoundException(search.Id, typeof(Domain.Brand));
            }

            var response = new SingleResponse<GetCartDto>
            {
                Data = new GetBrandDto
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    Email = brand.Email,
                    Description = brand.Description,
                    Slogan = brand.Slogan,
                    Manager = brand.Manager
                }
            };

            return response;

        }
    }
}
