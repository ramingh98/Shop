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
    internal class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        public BannerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Delete(Banner banner)
        {
            Context.Banners.Remove(banner);
        }
    }
}