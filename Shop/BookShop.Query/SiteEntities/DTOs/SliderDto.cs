using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;

namespace BookShop.Query.SiteEntities.DTOs
{
    public class SliderDto : BaseDto
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string ImageName { get; set; }
    }
}