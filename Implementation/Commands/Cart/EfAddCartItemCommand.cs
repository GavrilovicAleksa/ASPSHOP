using Application.Commands.Cart;
using Application.DataTransfer.CartDataTransfer;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Cart
{
    public class EfAddCartItemCommand : IAddCartItemCommand
    {
        private readonly Context _context;
        public int Id =>13;

        public string Name => "Insert Cart Item";

        public EfAddCartItemCommand(Context context)
        {
            this._context = context;
        }

        public void Execute(CartDto request)
        {
            var user = _context.Users.Find(request.UserId);

            if(user == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.User));
            }

            var cart = _context.Carts.Find(request.Id);

            if(cart == null)
            {
                cart = new Domain.Cart
                {
                    User = user,
                    CreatedAt = new DateTime()
                };
            }

           var product = _context.Products.Find(request.ProductId);


            if (user == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.Product));
            }

            cart.CartItem.Add(new Domain.CartItem { 
                Cart = cart,
                Product = product,
                Quantity = request.Quantity,
                CreatedAt = new DateTime()
            });

            _context.Carts.Add(cart);

            _context.SaveChanges();
        }
    }
}
