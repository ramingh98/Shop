using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace BookShop.Application.Sellers.Add
{
    public class AddSellerCommand : IBaseCommand
    {
        public AddSellerCommand(long userId, string shopName, string nationalCode)
        {
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
        }
        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
    }
}
