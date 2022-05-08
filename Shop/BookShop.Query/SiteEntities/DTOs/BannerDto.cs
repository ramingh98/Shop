﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SiteEntities.Enums;
using Common.Query;

namespace BookShop.Query.SiteEntities.DTOs
{
    public class BannerDto : BaseDto
    {
        public string Link { get; set; }
        public string ImageName { get; set; }
        public BannerPosition Position { get; set; }
    }
}