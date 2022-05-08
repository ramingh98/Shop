using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.OrderAgg;
using BookShop.Domain.OrderAgg.Enums;
using BookShop.Domain.OrderAgg.ValueObjects;
using Common.Query;

namespace BookShop.Query.Orders.DTOs
{
    public class OrderDto : BaseDto
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public OrderStatus Status { get; set; }
        public OrderDiscount? Discount { get; set; }
        public OrderAddress? Address { get; set; }
        public ShippingMethod? ShippingMethod { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}