using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.SiteEntities.DTOs;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.SiteEntities.Sliders.GetById
{
    internal class GetSliderByIdQueryHandler : IQueryHandler<GetSliderByIdQuery, SliderDto>
    {
        private ApplicationDbContext _context;

        public GetSliderByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SliderDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(q => q.Id == request.SliderId, cancellationToken);
            if (slider == null)
            {
                return null;
            }

            return new SliderDto()
            {
                Id = slider.Id,
                CreationDate = slider.CreationDate,
                ImageName = slider.ImageName,
                Link = slider.Link,
                Title = slider.Title
            };
        }
    }
}