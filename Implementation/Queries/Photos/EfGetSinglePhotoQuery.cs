using Application.DataTransfer.PhotoDataTransfer;
using Application.DataTransfer.Product;
using Application.Exceptions;
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
    public class EfGetSinglePhotoQuery : IGetSinglePhotoQuery
    {
        private readonly Context _context;

        public EfGetSinglePhotoQuery(Context context)
        {
            this._context = context;
        }
        public int Id => 2;

        public string Name => "Find a Photo by Id";

        public SingleResponse<GetPhotoDto> Execute(PhotoSearch search)
        {
            var photo = _context.Photos.Find(search.Id);

            if (photo == null)
            {
                throw new EntityNotFoundException(search.Id, typeof(Domain.Photo));
            }

            var response = new SingleResponse<GetPhotoDto>
            {
                Data = new GetPhotoDto
                {
                    Id = photo.Id,
                    Url = photo.url
                }
            };

            return response;

        }
    }
}
