using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;

namespace BookShop.Query.Products.DTOs
{
    public class ProductImageDto : BaseDto
    {
        public long ProductId { get; set; }
        public string ImageName { get; set; }
        public int Sequence { get; set; }
    }
}