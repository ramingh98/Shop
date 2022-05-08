using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Orders.DTOs;
using Common.Query;

namespace BookShop.Query.Orders.GetByFilter
{
    public class GetOrderByFilterQuery : QueryFilter<OrderFilterResult,OrderFilterParam>
    {
        public GetOrderByFilterQuery(OrderFilterParam filterParams) : base(filterParams)
        {
        }
    }
}