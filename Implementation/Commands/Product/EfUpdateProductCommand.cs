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
    public class EfUpdateProductCommand : IUpdateProductCommand
    {
        public int Id => 19;

        public string Name => "Update the Product";

        private readonly Context _context;

        public EfUpdateProductCommand(Context context)
        {
            _context = context;

        }

        public void Execute(ProductDto request)
        {
            var product = _context.Products.Find(request.Id);

            if (product == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.Product));
            }

            var brand = _context.Brands.Find(request.BrandId);

            if(brand == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.Brand));
            }

            var category = _context.Categories.Find(request.CategoryId);

            if (category == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.Category));
            }

            product.Name = request.Name;
            product.Price = request.Price;
            product.Brand = brand;
            //product.Category = category;
            product.UpdatedAt = new DateTime();

            _context.SaveChanges();
        }
    }
}
