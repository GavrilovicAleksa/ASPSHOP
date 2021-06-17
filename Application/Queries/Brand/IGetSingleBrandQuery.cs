using Application.DataTransfer.BrandDataTransfer;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Brand
{
    public interface IGetSingleBrandQuery : IQuery<BrandSearch, SingleResponse<GetBrandDto>>
    {
    }
}
