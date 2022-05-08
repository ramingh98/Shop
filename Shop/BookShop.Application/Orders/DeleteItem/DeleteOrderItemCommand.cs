using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace BookShop.Application.Orders.DeleteItem
{
    public record DeleteOrderItemCommand(long UserId, long ItemId) : IBaseCommand;
}
