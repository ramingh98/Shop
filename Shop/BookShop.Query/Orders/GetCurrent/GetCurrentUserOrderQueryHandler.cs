using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.OrderAgg.Enums;
using BookShop.Infrastructure.Persistent.Dapper;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Orders.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Orders.GetCurrent
{
    internal class GetCurrentUserOrderQueryHandler : IQueryHandler<GetCurrentUserOrderQuery, OrderDto>
    {
        private ApplicationDbContext _context;
        private DapperContext _dapperContext;

        public GetCurrentUserOrderQueryHandler(ApplicationDbContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        public async Task<OrderDto> Handle(GetCurrentUserOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(f => f.UserId == request.UserId && f.Status == OrderStatus.Pending, cancellationToken);
            if (order == null)
            {
                return null;
            }

            var orderDto = order.Map();
            orderDto.UserFullName = await _context.Users.Where(f => f.Id == orderDto.UserId)
                .Select(s => $"{s.Name} {s.Family}").FirstAsync(cancellationToken);

            orderDto.Items = await orderDto.GetOrderItems(_dapperContext);
            return orderDto;
        }
    }
}