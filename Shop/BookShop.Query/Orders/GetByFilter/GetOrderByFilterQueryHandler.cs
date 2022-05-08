using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Orders.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Orders.GetByFilter
{
    internal class GetOrderByFilterQueryHandler : IQueryHandler<GetOrderByFilterQuery, OrderFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetOrderByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Orders.OrderByDescending(q => q.Id).AsQueryable();
            if (@params.Status != null)
            {
                result = result.Where(q => q.Status == @params.Status);
            }
            if (@params.UserId != null)
            {
                result = result.Where(q => q.UserId == @params.UserId);
            }
            if (@params.StartDate != null)
            {
                result = result.Where(q => q.CreationDate.Date >= @params.StartDate.Value.Date);
            }
            if (@params.EndDate != null)
            {
                result = result.Where(q => q.CreationDate <= @params.EndDate.Value.Date);
            }

            var skip = (@params.PageId - 1) * @params.Take;

            var model = new OrderFilterResult()
            {
                Data = await result.Skip(skip).Take(@params.Take).Select(q => q.MapFilterData(_context)).ToListAsync(cancellationToken),
                FilterParam = @params
            };

            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}