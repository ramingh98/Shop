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
using BookShop.Query.Orders.GetByFilter;
using BookShop.Query.Orders.GetById;
using BookShop.Query.Orders.GetCurrent;
using Common.Application;
using MediatR;

namespace BookShop.Presentation.Facade.Orders
{
    internal class OrderFacade : IOrderFacade
    {
        private readonly IMediator _mediator;

        public OrderFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddOrderItemAsync(AddOrderItemCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> OrderCheckOutAsync(CheckOutOrderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteOrderItemAsync(DeleteOrderItemCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> IncreaseItemCountAsync(IncreaseOrderItemCountCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DecreaseItemCountAsync(DecreaseOrderItemCountCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OrderDto> GetOrderByIdAsync(long orderId)
        {
            return await _mediator.Send(new GetOrderByIdQuery(orderId));
        }

        public async Task<OrderFilterResult> GetOrdersByFilterAsync(OrderFilterParam param)
        {
            return await _mediator.Send(new GetOrderByFilterQuery(param));
        }

        public async Task<OrderDto> GetCurrentOrderAsync(long userId)
        {
            return await _mediator.Send(new GetCurrentUserOrderQuery(userId));
        }
    }
}