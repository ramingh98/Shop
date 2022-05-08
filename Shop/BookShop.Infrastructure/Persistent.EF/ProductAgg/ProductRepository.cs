using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.ProductAgg;
using BookShop.Domain.ProductAgg.Repositories;
using BookShop.Infrastructure._Utilities;

namespace BookShop.Infrastructure.Persistent.EF.ProductAgg
{
    internal class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}