using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Products.Enums;
using Common.Query.Filter;

namespace BookShop.Query.Products.DTOs
{
    public class ProductShopFilterParam : BaseFilterParam
    {
        public string? CategorySlug { get; set; } = "";
        public string? Search { get; set; } = "";
        public bool OnlyAvailableProducts { get; set; } = false;
        public bool JustHasDiscount { get; set; } = false;
        public ProductSearchOrderBy SearchOrderBy { get; set; } = ProductSearchOrderBy.Cheapest;
    }
}