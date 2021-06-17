using Application.Commands.Product;
using Application.DataTransfer.Product;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Product
{
    public class EfRemoveProductCommand : IRemoveProductCommand
    {
        public int Id => 5;

        public string Name => "Removes the Product";

        private readonly Context _context;

        public EfRemoveProductCommand(Context context)
        {
            _context = context;

        }

        public void Execute(RemoveProductDto request)
        {
            var product = _context.Products.Find(request.Id);

            if (product != null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.Product));
            }

            if (request.Hard == false)
            {
                product.DeletedAt = new DateTime();
            }
            else
            {
                _context.Products.Remove(product);
            }

            _context.SaveChanges();
        }
    }
}
