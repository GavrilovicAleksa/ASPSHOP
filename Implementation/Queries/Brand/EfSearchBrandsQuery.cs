using Application.DataTransfer.BrandDataTransfer;
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
    public class EfSearchBrandsQuery : ISearchBrandsQuery
    {
        private readonly Context _context;

        public EfSearchBrandsQuery(Context context)
        {
            this._context = context;
        }

        public int Id => 18;

        public string Name => "Brand Search";

        public PagedResponse<GetBrandDto> Execute(BrandSearch search)
        {
            var query = _context.Brands.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var reponse = new PagedResponse<GetCartDto>
            {
                Page = search.Page,
                PerPage = search.PerPage,
                Count = query.Count(),
                Data = query.Skip(skipCount).Take(search.PerPage).Select(x => new GetBrandDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Description = x.Description,
                    Slogan = x.Slogan,
                    Manager = x.Manager
                }).ToList()
            };

            return reponse;
        }
    }
}
