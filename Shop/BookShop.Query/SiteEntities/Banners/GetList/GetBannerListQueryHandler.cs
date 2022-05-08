using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.SiteEntities.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.SiteEntities.Banners.GetList
{
    internal class GetBannerListQueryHandler : IQueryHandler<GetBannerListQuery, List<BannerDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetBannerListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BannerDto>> Handle(GetBannerListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Banners.OrderByDescending(q => q.Id).Select(q => new BannerDto()
            {
                Id = q.Id,
                CreationDate = q.CreationDate,
                ImageName = q.ImageName,
                Link = q.Link,
                Position = q.Position
            }).ToListAsync(cancellationToken);
        }
    }
}