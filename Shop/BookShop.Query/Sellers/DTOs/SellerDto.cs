using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SellerAgg.Enums;
using Common.Query;

namespace BookShop.Query.Sellers.DTOs
{
    public class SellerDto : BaseDto
    {
        public long UserId { get; set; }
        public string ShopName { get; set; }
        public string NationalCode { get; set; }
        public SellerStatus Status { get; set; }
    }
}