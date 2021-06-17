using Application.DataTransfer.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Product
{
    public interface IRemoveProductCommand : ICommand<RemoveProductDto>
    {
    }
}
