using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Products.DTOs;
using Common.Query;

namespace BookShop.Query.Products.GetByFilter
{
    public class GetProductsByFilterQuery : QueryFilter<ProductFilterResult,ProductFilterParam>
    {
        public GetProductsByFilterQuery(ProductFilterParam filterParams) : base(filterParams)
        {

        }
    }
}