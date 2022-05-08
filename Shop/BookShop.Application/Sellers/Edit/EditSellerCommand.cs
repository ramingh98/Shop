using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SellerAgg.Enums;
using Common.Application;

namespace BookShop.Application.Sellers.Edit
{
    public record EditSellerCommand(long Id, string ShopName, string NationalCode, SellerStatus Status) : IBaseCommand;
}
