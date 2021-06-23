using Application.DataTransfer;
using Application.DataTransfer.BrandDataTransfer;
using Application.DataTransfer.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Order
{
    public interface IRemoveOrderCommand : ICommand<RemoveEntityDto>
    {
    }
}
