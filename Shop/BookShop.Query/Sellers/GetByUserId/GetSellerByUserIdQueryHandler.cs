using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Sellers.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Sellers.GetByUserId
{
    internal class GetSellerByUserIdQueryHandler : IQueryHandler<GetSellerByUserIdQuery, SellerDto>
    {
        private readonly ApplicationDbContext _context;

        public GetSellerByUserIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SellerDto> Handle(GetSellerByUserIdQuery request, CancellationToken cancellationToken)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(f => f.UserId == request.UserId,
                cancellationToken: cancellationToken);
            return seller.Map();
        }
    }
}