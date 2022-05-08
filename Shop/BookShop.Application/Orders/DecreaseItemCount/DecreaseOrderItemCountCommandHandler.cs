using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.OrderAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Orders.DecreaseItemCount
{
    public class DecreaseOrderItemCountCommandHandler : IBaseCommandHandler<DecreaseOrderItemCountCommand>
    {
        private IOrderRepository _orderRepository;

        public DecreaseOrderItemCountCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OperationResult> Handle(DecreaseOrderItemCountCommand request, CancellationToken cancellationToken)
        {
            var currrentItem = await _orderRepository.GetCurrentUserOrder(request.UserId);
            if (currrentItem == null)
            {
                return OperationResult.NotFound();
            }
            currrentItem.DecreaseItemCount(request.ItemId, request.Count);
            await _orderRepository.Save();
            return OperationResult.Success();
        }
    }
}
