using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.OrderAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Orders.IncreaseItemCount
{
    public class IncreaseOrderItemCountCommandHandler : IBaseCommandHandler<IncreaseOrderItemCountCommand>
    {
        private IOrderRepository _orderRepository;

        public IncreaseOrderItemCountCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OperationResult> Handle(IncreaseOrderItemCountCommand request, CancellationToken cancellationToken)
        {
            var currentItem = await _orderRepository.GetCurrentUserOrder(request.UserId);
            if (currentItem == null)
            {
                return OperationResult.NotFound();
            }
            currentItem.IncreaseItemCount(request.ItemId, request.Count);
            await _orderRepository.Save();
            return OperationResult.Success();
        }
    }
}