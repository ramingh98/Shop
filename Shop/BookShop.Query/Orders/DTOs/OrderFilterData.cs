using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.OrderAgg.Enums;
using Common.Query;

namespace BookShop.Query.Orders.DTOs
{
    public class OrderFilterData : BaseDto
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public OrderStatus Status { get; set; }
        public string? Shire { get; set; }
        public string? City { get; set; }
        public string? ShippingType { get; set; }
        public int TotalPrice { get; set; }
        public int TotalItemCount { get; set; } 
    }
}