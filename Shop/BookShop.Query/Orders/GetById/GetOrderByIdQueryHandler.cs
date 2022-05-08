using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.Dapper;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Orders.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Orders.GetById
{
    internal class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly DapperContext _dapperContext;

        public GetOrderByIdQueryHandler(ApplicationDbContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(q => q.Id == request.OrderId, cancellationToken);
            if (order == null)
            {
                return null;
            }

            var orderDto = order.Map();
            orderDto.UserFullName = await _context.Users.Where(q => q.Id == orderDto.UserId)
                .Select(q => $"{q.Name} {q.Family}").FirstOrDefaultAsync(cancellationToken);
            orderDto.Items = await orderDto.GetOrderItems(_dapperContext);
            return orderDto;
        }
    }
}