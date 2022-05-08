using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.OrderAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Orders.DeleteItem
{
    public class DeleteOrderItemCommandHandler : IBaseCommandHandler<DeleteOrderItemCommand>
    {
        private IOrderRepository _orderRepository;

        public DeleteOrderItemCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OperationResult> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _orderRepository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
            {
                return OperationResult.NotFound();
            }
            currentOrder.RemoveItem(request.ItemId);
            await _orderRepository.Save();
            return OperationResult.Success();
        }
    }
}
