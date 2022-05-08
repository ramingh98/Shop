using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.SiteEntities.Sliders.Add
{
    public class AddSliderCommand : IBaseCommand
    {
        public AddSliderCommand(string link, IFormFile imageFile, string title)
        {
            Link = link;
            ImageFile = imageFile;
            Title = title;
        }
        public string Link { get; private set; }
        public IFormFile ImageFile { get; private set; }
        public string Title { get; private set; }
    }
}
