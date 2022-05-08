using BookShop.API.Infrastructures.Security;
using BookShop.Application.Orders.AddItem;
using BookShop.Application.Orders.CheckOut;
using BookShop.Application.Orders.DecreaseItemCount;
using BookShop.Application.Orders.DeleteItem;
using BookShop.Application.Orders.IncreaseItemCount;
using BookShop.Domain.RoleAgg.Enums;
using BookShop.Presentation.Facade.Orders;
using BookShop.Query.Orders.DTOs;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        private readonly IOrderFacade _orderFacade;

        public OrderController(IOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        [CheckPermission(Permission.OrderManagement)]
        [HttpGet]
        public async Task<ApiResult<OrderFilterResult>> GetOrdersByFilter(OrderFilterParam param)
        {
            var result = await _orderFacade.GetOrdersByFilterAsync(param);
            return QueryResult(result);
        }

        [HttpGet("current")]
        public async Task<ApiResult<OrderDto>> GetCurrentOrder()
        {
            var result = await _orderFacade.GetCurrentOrderAsync(User.GetUserId());
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<OrderDto>> GetOrderById(long id)
        {
            var result = await _orderFacade.GetOrderByIdAsync(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> AddOrderItem(AddOrderItemCommand command)
        {
            var result = await _orderFacade.AddOrderItemAsync(command);
            return CommandResult(result);
        }

        [HttpPost("checkOut")]
        public async Task<ApiResult> OrderCheckOut(CheckOutOrderCommand command)
        {
            var result = await _orderFacade.OrderCheckOutAsync(command);
            return CommandResult(result);
        }

        [HttpPut("orderItem/IncreaseCount")]
        public async Task<ApiResult> IncreaseOrderItemCount(IncreaseOrderItemCountCommand command)
        {
            var result = await _orderFacade.IncreaseItemCountAsync(command);
            return CommandResult(result);
        }

        [HttpPut("orderItem/DecreaseCount")]
        public async Task<ApiResult> DecreaseOrderItemCount(DecreaseOrderItemCountCommand command)
        {
            var result = await _orderFacade.DecreaseItemCountAsync(command);
            return CommandResult(result);
        }

        [HttpDelete("orderItem/{itemId}")]
        public async Task<ApiResult> DeleteOrderItem(long itemId)
        {
            var result = await _orderFacade.DeleteOrderItemAsync(new DeleteOrderItemCommand(User.GetUserId(), itemId));
            return CommandResult(result);
        }
    }
}