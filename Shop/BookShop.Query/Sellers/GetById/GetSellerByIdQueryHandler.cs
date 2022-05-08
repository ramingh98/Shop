using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Sellers.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Sellers.GetById
{
    internal class GetSellerByIdQueryHandler : IQueryHandler<GetSellerByIdQuery, SellerDto>
    {
        private readonly ApplicationDbContext _context;

        public GetSellerByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SellerDto> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
        {
            var seller = await _context.Sellers.FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken);
            if (seller == null)
            {
                return null;
            }
            return seller.Map();
        }
    }
}