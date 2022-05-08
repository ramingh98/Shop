using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query.Filter;

namespace BookShop.Query.Products.DTOs
{
    public class ProductFilterParam : BaseFilterParam
    {
        public string? Title { get; set; }
        public long? Id { get; set; }
        public string? Slug { get; set; }
    }
}