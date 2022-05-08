using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Products.DTOs;
using Common.Query;

namespace BookShop.Query.Products.GetForShop
{
    public class GetProductForShopQuery : QueryFilter<ProductShopResult, ProductShopFilterParam>
    {
        public GetProductForShopQuery(ProductShopFilterParam filterParams) : base(filterParams)
        {

        }
    }
}