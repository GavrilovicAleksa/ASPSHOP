using Application.Commands.Brand;
using Application.Commands.Photo;
using Application.DataTransfer;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Brand
{
    public class EfRemovePhotoCommand : IRemovePhotoCommand
    {

        public int Id => 17;

        public string Name => "Removes the photo";

        private readonly Context _context;

        public EfRemovePhotoCommand(Context context)
        {
            _context = context;

        }

        public void Execute(RemoveEntityDto request)
        {
            var photo = _context.Photos.Find(request.Id);

            if (photo != null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.Photo));
            }

            if (request.Hard == false)
            {
                photo.DeletedAt = new DateTime();
            }
            else
            {
                _context.Photos.Remove(photo);
            }

            _context.SaveChanges();
        }
    }
}
