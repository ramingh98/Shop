using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.SiteEntities.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.SiteEntities.Banners.GetById
{
    internal class GetBannerByIdQueryHandler : IQueryHandler<GetBannerByIdQuery, BannerDto>
    {
        private ApplicationDbContext _context;

        public GetBannerByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BannerDto> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var banner = await _context.Banners.FirstOrDefaultAsync(q => q.Id == request.BannerId, cancellationToken);
            if (banner == null)
            {
                return null;
            }

            return new BannerDto()
            {
                Id = banner.Id,
                CreationDate = banner.CreationDate,
                ImageName = banner.ImageName,
                Link = banner.Link,
                Position = banner.Position
            };
        }
    }
}