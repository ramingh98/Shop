using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.ProductAgg.Services
{
    public interface IProductDomainService
    {
        bool IsSlugExist(string slug);
    }
}
