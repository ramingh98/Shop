﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.SiteEntities.DTOs;
using Common.Query;

namespace BookShop.Query.SiteEntities.Banners.GetById
{
    public record GetBannerByIdQuery(long BannerId) : IQuery<BannerDto>;
}