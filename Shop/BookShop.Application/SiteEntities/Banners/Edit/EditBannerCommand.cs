using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SiteEntities.Enums;
using Common.Application;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.SiteEntities.Banners.Edit
{
    public class EditBannerCommand : IBaseCommand
    {
        public EditBannerCommand(long id, string link, IFormFile? imageFile, BannerPosition position)
        {
            Id = id;
            Link = link;
            ImageFile = imageFile;
            Position = position;
        }
        public long Id { get; private set; }
        public string Link { get; private set; }
        public IFormFile? ImageFile { get; private set; }
        public BannerPosition Position { get; private set; }
    }
}
