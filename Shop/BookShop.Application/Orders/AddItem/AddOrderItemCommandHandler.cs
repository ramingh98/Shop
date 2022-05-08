using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.OrderAgg;
using BookShop.Domain.OrderAgg.Repositories;
using BookShop.Domain.SellerAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Orders.AddItem
{
    public class AddOrderItemCommandHandler : IBaseCommandHandler<AddOrderItemCommand>
    {
        private IOrderRepository _orderRepository;
        private ISellerRepository _sellerRepository;

        public AddOrderItemCommandHandler(IOrderRepository orderRepository, ISellerRepository sellerRepository)
        {
            _orderRepository = orderRepository;
            _sellerRepository = sellerRepository;
        }
        public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _sellerRepository.GetInventoryById(request.InventoryId);
            if (inventory == null)
            {
                return OperationResult.NotFound();
            }

            if (inventory.Count < request.Count)
            {
                return OperationResult.Error("تعداد محصول درخواستی بیشتر از حد موجود میباشد");
            }

            var order = await _orderRepository.GetCurrentUserOrder(request.UserId);
            if (order == null)
            {
                order = new Order(request.UserId);
            }
            order.AddItem(new OrderItem(request.InventoryId, request.Count, inventory.Price));
            if (IsItemCountBiggerThanInventoryCount(inventory, order))
            {
                return OperationResult.Error("تعداد محصول درخواستی بیشتر از حد موجود میباشد");
            }
            await _orderRepository.Save();
            return OperationResult.Success();
        }

        private bool IsItemCountBiggerThanInventoryCount(InventoryResult inventory, Order order)
        {
            var orderItem = order.Items.FirstOrDefault(q => q.InventoryId == inventory.Id);
            if (orderItem.Count > inventory.Count)
            {
                return true;
            }

            return false;
        }
    }
}
