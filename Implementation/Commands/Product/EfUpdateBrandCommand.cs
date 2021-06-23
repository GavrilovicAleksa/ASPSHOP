using Application.Commands.Brand;
using Application.Commands.Photo;
using Application.DataTransfer.BrandDataTransfer;
using Application.DataTransfer.PhotoDataTransfer;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Brand
{
    public class EfUpdatePhotoCommand : IUpdatePhotoCommand
    {
        public int Id => 4;

        public string Name => "User Update";

        private readonly Context _context;

        public EfUpdatePhotoCommand(Context context)
        {
            _context = context;

        }

        public void Execute(PhotoDto request)
        {
            var photo = _context.Photos.Find(request.Id);

            if (photo == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.Photo));
            }

            var owner = _context.Users.Find(request.UserId);

            if(owner == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.User));
            }

            var product = _context.Products.Find(request.ProductId);

            if (product == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.Product));
            }

            photo.User = owner;
            photo.url = request.Url;
            photo.Product = product;
            photo.UpdatedAt = new DateTime();

            _context.SaveChanges();
        }
    }
}
