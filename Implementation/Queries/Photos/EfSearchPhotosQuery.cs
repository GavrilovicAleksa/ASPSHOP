using Application.DataTransfer.PhotoDataTransfer;
using Application.DataTransfer.Product;
using Application.Queries;
using Application.Queries.Brand;
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
    public class EfSearchPhotosQuery : ISearchPhotosQuery
    {
        private readonly Context _context;

        public EfSearchPhotosQuery(Context context)
        {
            this._context = context;
        }

        public int Id => 18;

        public string Name => "Brand Search";

        public PagedResponse<GetPhotoDto> Execute(PhotoSearch search)
        {
            var query = _context.Photos.AsQueryable();

            query = query.Where(x => x.User.Id.Equals(search.Id));

            var skipCount = search.PerPage * (search.Page - 1);

            var reponse = new PagedResponse<GetPhotoDto>
            {
                Page = search.Page,
                PerPage = search.PerPage,
                Count = query.Count(),
                Data = query.Skip(skipCount).Take(search.PerPage).Select(x => new GetPhotoDto
                {
                    Id = x.Id,
                    Url = x.url,
                }).ToList()
            };

            return reponse;
        }
    }
}
