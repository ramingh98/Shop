using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SiteEntities;
using BookShop.Domain.SiteEntities.Repositories;
using BookShop.Infrastructure._Utilities;

namespace BookShop.Infrastructure.Persistent.EF.SiteEntities.Repositories
{
    internal class SliderRepository : BaseRepository<Slider>, ISliderRepository
    {
        public SliderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Delete(Slider slider)
        {
            Context.Sliders.Remove(slider);
        }
    }
}