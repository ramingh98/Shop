using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Orders.AddItem;
using BookShop.Application.Orders.CheckOut;
using BookShop.Application.Orders.DecreaseItemCount;
using BookShop.Application.Orders.DeleteItem;
using BookShop.Application.Orders.IncreaseItemCount;
using BookShop.Query.Orders.DTOs;
using Common.Application;

namespace BookShop.Presentation.Facade.Orders
{
    public interface IOrderFacade
    {
        Task<OperationResult> AddOrderItemAsync(AddOrderItemCommand command);
        Task<OperationResult> OrderCheckOutAsync(CheckOutOrderCommand command);
        Task<OperationResult> DeleteOrderItemAsync(DeleteOrderItemCommand command);
        Task<OperationResult> IncreaseItemCountAsync(IncreaseOrderItemCountCommand command);
        Task<OperationResult> DecreaseItemCountAsync(DecreaseOrderItemCountCommand command);
        Task<OrderDto> GetOrderByIdAsync(long orderId);
        Task<OrderFilterResult> GetOrdersByFilterAsync(OrderFilterParam param);
        Task<OrderDto> GetCurrentOrderAsync(long userId);
    }
}