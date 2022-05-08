using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace BookShop.Application.Orders.IncreaseItemCount
{
    public record IncreaseOrderItemCountCommand(long UserId, long ItemId, int Count) : IBaseCommand;
}
