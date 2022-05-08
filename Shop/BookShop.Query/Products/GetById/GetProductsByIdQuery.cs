using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Products.DTOs;
using Common.Query;

namespace BookShop.Query.Products.GetById
{
    public record GetProductsByIdQuery(long ProductId) : IQuery<ProductDto>;
}