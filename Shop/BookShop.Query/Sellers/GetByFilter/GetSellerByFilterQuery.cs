using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Sellers.DTOs;
using Common.Query;

namespace BookShop.Query.Sellers.GetByFilter
{
    public class GetSellerByFilterQuery : QueryFilter<SellerFilterResult, SellerFilterParam>
    {
        public GetSellerByFilterQuery(SellerFilterParam filterParams) : base(filterParams)
        {

        }
    }
}