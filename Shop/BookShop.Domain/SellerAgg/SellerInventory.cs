using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;

namespace BookShop.Domain.SellerAgg
{
    public class SellerInventory : BaseEntity
    {
        public SellerInventory(long productId, int count, int price, int? discountPercentage)
        {
            if (count < 0 || price < 1)
            {
                throw new InvalidDomainDataException();
            }
            ProductId = productId;
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }
        public long SellerId { get; internal set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? DiscountPercentage { get; private set; }

        public void Edit(int count, int price, int? discountPercentage)
        {
            if (price < 1 || count < 0)
            {
                throw new InvalidDomainDataException();
            }
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }
    }
}
