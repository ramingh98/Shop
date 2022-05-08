using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Orders.DTOs;
using Common.Query;

namespace BookShop.Query.Orders.GetCurrent
{
    public record GetCurrentUserOrderQuery(long UserId) : IQuery<OrderDto>;
}