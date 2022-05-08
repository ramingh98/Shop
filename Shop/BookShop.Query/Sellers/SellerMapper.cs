using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SellerAgg;
using BookShop.Query.Sellers.DTOs;

namespace BookShop.Query.Sellers
{
    public static class SellerMapper
    {
        public static SellerDto Map(this Seller seller)
        {
            if (seller == null)
                return null;

            return new SellerDto()
            {
                Id = seller.Id,
                CreationDate = seller.CreationDate,
                Status = seller.Status,
                NationalCode = seller.NationalCode,
                ShopName = seller.ShopName,
                UserId = seller.UserId
            };
        }
    }
}