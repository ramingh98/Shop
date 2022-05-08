using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Repository;

namespace BookShop.Domain.ProductAgg.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
    }
}