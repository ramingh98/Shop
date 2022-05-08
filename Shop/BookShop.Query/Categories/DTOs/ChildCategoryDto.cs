using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.ValueObjects;
using Common.Query;

namespace BookShop.Query.Categories.DTOs
{
    public class ChildCategoryDto : BaseDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public SeoData SeoData { get; set; }
        public long ParentId { get; set; }
        public List<SecondaryChildCategoryDto> Children { get; set; }
    }
}