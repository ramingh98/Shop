using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Categories.DTOs;
using Common.Query.Filter;

namespace BookShop.Query.Products.DTOs
{
    public class ProductShopResult : BaseFilter<ProductShopDto, ProductShopFilterParam>
    {
        public CategoryDto? CategoryDto { get; set; }
    }
}