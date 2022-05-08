using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.OrderAgg.Enums;
using Common.Query.Filter;

namespace BookShop.Query.Orders.DTOs
{
    public class OrderFilterParam : BaseFilterParam
    {
        public long? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public OrderStatus? Status { get; set; }
    }
}