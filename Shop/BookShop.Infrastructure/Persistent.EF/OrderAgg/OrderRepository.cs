using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.OrderAgg;
using BookShop.Domain.OrderAgg.Enums;
using BookShop.Domain.OrderAgg.Repositories;
using BookShop.Infrastructure._Utilities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Persistent.EF.OrderAgg
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Order?> GetCurrentUserOrder(long userId)
        {
            return await Context.Orders.AsTracking().FirstOrDefaultAsync(f => f.UserId == userId && f.Status == OrderStatus.Pending);
        }
    }
}