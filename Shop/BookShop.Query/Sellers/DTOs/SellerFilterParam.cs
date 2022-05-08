using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query.Filter;

namespace BookShop.Query.Sellers.DTOs
{
    public class SellerFilterParam : BaseFilterParam
    {
        public string ShopName { get; set; }
        public string NationalCode { get; set; }
    }
}