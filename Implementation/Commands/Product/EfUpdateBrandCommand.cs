using Application.Commands.Brand;
using Application.DataTransfer.BrandDataTransfer;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Brand
{
    public class EfUpdatePhotoCommand : IUpdateBrandCommand
    {
        public int Id => 4;

        public string Name => "User Update";

        private readonly Context _context;

        public EfUpdatePhotoCommand(Context context)
        {
            _context = context;

        }

        public void Execute(BrandDto request)
        {
            var brand = _context.Brands.Find(request.Id);

            if (brand == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.Brand));
            }

            var manager = _context.Users.Find(request.UserId);

            if(manager == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.User));
            }

            brand.Name = request.Name;
            brand.Email = request.Email;
            brand.Description = request.Description;
            brand.Slogan = request.Slogan;
            brand.Manager = manager;
            brand.UpdatedAt = new DateTime();

            _context.SaveChanges();
        }
    }
}
