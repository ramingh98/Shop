using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Orders.DTOs;
using Common.Query;

namespace BookShop.Query.Orders.GetById
{
    public record GetOrderByIdQuery(long OrderId) : IQuery<OrderDto>;
}