using Application.Commands.Cart;
using Application.DataTransfer;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Cart
{
    public class EfRemoveCartItemCommand : IRemoveCartItemCommand
    {
        public int Id => 14;

        public string Name => "Removes the Cart Item from Cart";

        private readonly Context _context;

        public EfRemoveCartItemCommand(Context context)
        {
            _context = context;

        }

        public void Execute(RemoveEntityDto request)
        {
            var cartItem = _context.CartItems.Find(request.Id);

            if (cartItem != null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.CartItem));
            }

            _context.CartItems.Remove(cartItem);

            _context.SaveChanges();
        }
    }
}
