using Application.DataTransfer.PhotoDataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Photo
{
    public interface IUpdatePhotoCommand : ICommand<PhotoDto>
    {
    }
}
