using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Sellers.DTOs;
using Common.Query;

namespace BookShop.Query.Sellers.Inventories.GetList
{
    public record GetInventoryListQuery(long SellerId) : IQuery<List<InventoryDto>>;
}