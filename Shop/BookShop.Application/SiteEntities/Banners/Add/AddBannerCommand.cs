using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SiteEntities.Enums;
using Common.Application;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.SiteEntities.Banners.Add
{
    public class AddBannerCommand : IBaseCommand
    {
        public AddBannerCommand(string link, IFormFile imageFile, BannerPosition position)
        {
            Link = link;
            ImageFile = imageFile;
            Position = position;
        }
        public string Link { get; private set; }
        public IFormFile ImageFile { get; private set; }
        public BannerPosition Position { get; private set; }
    }
}
