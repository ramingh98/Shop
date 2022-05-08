using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Users.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Users.GetByFilter
{
    internal class GetUserByFilterQueryHandler : IQueryHandler<GetUserByFilterQuery, UserFilterResult>
    {
        private ApplicationDbContext _context;

        public GetUserByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserFilterResult> Handle(GetUserByFilterQuery request, CancellationToken cancellationToken)
        {
            var param = request.FilterParams;
            var result = _context.Users.OrderByDescending(q => q.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(param.Email))
                result = result.Where(r => r.Email.Contains(param.Email));

            if (!string.IsNullOrWhiteSpace(param.PhoneNumber))
                result = result.Where(r => r.PhoneNumber.Contains(param.PhoneNumber));

            if (param.Id != null)
                result = result.Where(r => r.Id == param.Id);

            var skip = (param.PageId - 1) * param.Take;
            var model = new UserFilterResult()
            {
                Data = await result.Skip(skip).Take(param.Take).Select(q => q.MapFilterData()).ToListAsync(),
                FilterParam = param
            };

            model.GeneratePaging(result, param.Take, param.PageId);
            return model;
        }
    }
}