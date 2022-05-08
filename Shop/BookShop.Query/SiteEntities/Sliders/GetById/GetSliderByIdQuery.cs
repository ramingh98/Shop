using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.SiteEntities.DTOs;
using Common.Query;

namespace BookShop.Query.SiteEntities.Sliders.GetById
{
    public record GetSliderByIdQuery(long SliderId) : IQuery<SliderDto>;
}