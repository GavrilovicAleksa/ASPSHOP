using Application.Commands.Brand;
using Application.Commands.Photo;
using Application.DataTransfer.BrandDataTransfer;
using Application.DataTransfer.PhotoDataTransfer;
using Application.Exceptions;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Brand
{
    public class EfInsertPhotoCommand : ICreatePhotoCommand
    {
        private readonly Context _context;

        private readonly CreatePhotoValidator _validator;

        public EfInsertPhotoCommand(Context context, CreatePhotoValidator validator)
        {
            this._validator = validator;
            this._context = context;
        }
        public int Id => 16;

        public string Name => "Create a Brand";

        public void Execute(PhotoDto request)
        {
            this._validator.ValidateAndThrow(request);


            var user = _context.Users.Find(request.UserId);

            var product = _context.Products.Find(request.ProductId);

            if(user == null && product == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.Photo));
            }

            var photo = new Domain.Photo
            {
                url = request.Url,
                Product = product,
                User = user,
                CreatedAt = new DateTime()
            };

            this._context.Photos.Add(photo);

            this._context.SaveChanges();
        }
    }
}
