using Application.Commands.Cart;
using Application.Commands.Order;
using Application.DataTransfer.CartDataTransfer;
using Application.DataTransfer.Order;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Order
{
    public class EfCreateOrderCommand : IAddOrderItemCommand
    {
        private readonly Context _context;
        public int Id =>13;

        public string Name => "Create order";

        public EfCreateOrderCommand(Context context)
        {
            this._context = context;
        }

        public void Execute(OrderDto request)
        {
            var user = _context.Users.Find(request.UserId);

            if(user == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domain.User));
            }

            Domain.Address address = null;

            if (request.Street != null && request.ZipCode != null)
            {
                address = 
                     new Domain.Address
                     {
                         ZipCode = (int)request.ZipCode,
                         Street = request.Street
                     };
            }

            List<Domain.ProductOrder> collection = new List<Domain.ProductOrder>();

            var order = new Domain.Order
            {
                PlacedAt = DateTime.Parse(request.PlacedAt),
                User = user,
                Address = address,
            };

            _context.Orders.Add(order);

            _context.SaveChanges();
        }
    }
}
