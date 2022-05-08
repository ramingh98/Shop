using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Sellers.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Sellers.GetByFilter
{
    internal class GetSellerByFilterQueryHandler : IQueryHandler<GetSellerByFilterQuery, SellerFilterResult>
    {
        private ApplicationDbContext _context;

        public GetSellerByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SellerFilterResult> Handle(GetSellerByFilterQuery request, CancellationToken cancellationToken)
        {
            var param = request.FilterParams;
            var result = _context.Sellers.OrderByDescending(q => q.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(param.NationalCode))
                result = result.Where(r => r.NationalCode.Contains(param.NationalCode));

            if (!string.IsNullOrWhiteSpace(param.ShopName))
                result = result.Where(r => r.ShopName.Contains(param.ShopName));

            var skip = (param.PageId - 1) * param.Take;

            var sellerResult = new SellerFilterResult()
            {
                FilterParam = param,
                Data = await result.Skip(skip).Take(param.Take).Select(q => q.Map()).ToListAsync(cancellationToken)
            };

            sellerResult.GeneratePaging(result, param.Take, param.PageId);
            return sellerResult;
        }
    }
}