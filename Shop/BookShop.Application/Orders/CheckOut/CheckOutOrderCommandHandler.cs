using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.OrderAgg;
using BookShop.Domain.OrderAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Orders.CheckOut
{
    public class CheckOutOrderCommandHandler : IBaseCommandHandler<CheckOutOrderCommand>
    {
        private IOrderRepository _orderRepository;

        public CheckOutOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OperationResult> Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _orderRepository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
            {
                return OperationResult.NotFound();
            }

            var address = new OrderAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress,
                request.PhoneNumber, request.Name, request.Family, request.NationalCode);
            currentOrder.CheckOut(address);
            await _orderRepository.Save();
            return OperationResult.Success();
        }
    }
}