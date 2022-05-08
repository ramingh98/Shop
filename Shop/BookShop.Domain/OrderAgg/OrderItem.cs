using System;
using System.Collections.Generic;
using System.Linq;
using Common.Domain;
using Common.Domain.Exceptions;

namespace BookShop.Domain.OrderAgg
{
    public class OrderItem : BaseEntity
    {
        public OrderItem(long inventoryId, int count, int price)
        {
            InventoryId = inventoryId;
            Count = count;
            Price = price;
        }

        public long OrderId { get; internal set; }
        public long InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int TotalPrice => Price * Count;

        public void IncreaseCount(int count)
        {
            Count += count;
        }

        public void DecreaseCount(int count)
        {
            if (Count == 1)
            {
                return;
            }

            if (Count - count <= 0)
            {
                return;
            }

            Count -= count;
        }

        public void ChangeCount(int count)
        {
            CountGuard(count);
            Count = count;
        }

        public void SetPrice(int price)
        {
            PriceGuard(price);
            Price = price;
        }

        public void PriceGuard(int price)
        {
            if (price < 1)
                throw new InvalidDomainDataException("مبلغ معتبر وارد نمایید");
        }

        public void CountGuard(int count)
        {
            if (count < 1)
                throw new InvalidDomainDataException();
        }
    }
}
