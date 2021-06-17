using Application.DataTransfer.PhotoDataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Brand
{
    public interface IGetSinglePhotoQuery : IQuery<PhotoSearch, SingleResponse<GetPhotoDto>>
    {
    }
}
