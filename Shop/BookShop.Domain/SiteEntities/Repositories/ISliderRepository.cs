using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SiteEntities;
using Common.Domain.Repository;

namespace BookShop.Domain.SiteEntities.Repositories
{
    public interface ISliderRepository : IBaseRepository<Slider>
    {
        void Delete(Slider slider);
    }
}