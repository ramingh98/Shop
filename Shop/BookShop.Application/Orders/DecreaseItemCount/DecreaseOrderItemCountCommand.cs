using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using FluentValidation;

namespace BookShop.Application.Orders.DecreaseItemCount
{
    public record DecreaseOrderItemCountCommand(long UserId, long ItemId, int Count) : IBaseCommand;
}
