using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.SiteEntities.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.SiteEntities.Sliders.GetList
{
    internal class GetSliderListQueryHandler : IQueryHandler<GetSliderListQuery, List<SliderDto>>
    {
        private ApplicationDbContext _context;

        public GetSliderListQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SliderDto>> Handle(GetSliderListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Sliders.OrderByDescending(q => q.Id).Select(q => new SliderDto()
            {
                Id = q.Id,
                CreationDate = q.CreationDate,
                ImageName = q.ImageName,
                Link = q.Link,
                Title = q.Title
            }).ToListAsync(cancellationToken);
        }
    }
}