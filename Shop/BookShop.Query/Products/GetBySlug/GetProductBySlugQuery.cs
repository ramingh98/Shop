using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Products.DTOs;
using Common.Query;

namespace BookShop.Query.Products.GetBySlug
{
    public class GetProductBySlugQuery : IQuery<ProductDto>
    {
        public GetProductBySlugQuery(string slug)
        {
            Slug = slug;
        }
        public string Slug { get; private set; }
    }
}