using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.OrderAgg;
using Common.Domain.Repository;

namespace BookShop.Domain.OrderAgg.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetCurrentUserOrder(long userId);
    }
}
