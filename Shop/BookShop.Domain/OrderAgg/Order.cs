using System;
using System.Collections.Generic;
using BookShop.Domain.OrderAgg.Enums;
using BookShop.Domain.OrderAgg.ValueObjects;
using Common.Domain;
using Common.Domain.Exceptions;

namespace BookShop.Domain.OrderAgg
{
    public class Order : AggregateRoot
    {
        public Order()
        {

        }

        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
            Items = new List<OrderItem>();
        }

        public long UserId { get; private set; }
        public OrderStatus Status { get; private set; }
        public OrderDiscount? Discount { get; private set; }
        public OrderAddress? Address { get; private set; }
        public ShippingMethod? ShippingMethod { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public DateTime? LastUpdate { get; set; }
        public int ItemCount => Items.Count;
        public int TotalPrice
        {
            get
            {
                var totalPrice = Items.Sum(q => q.Price);
                if (ShippingMethod != null)
                {
                    totalPrice += ShippingMethod.Cost;
                }

                if (Discount != null)
                {
                    totalPrice -= Discount.Amount;
                }

                return totalPrice;
            }
        }

        public void AddItem(OrderItem item)
        {
            ChangeOrderGuard();
            var oldItem = Items.FirstOrDefault(q => q.InventoryId == item.InventoryId);
            if (oldItem != null)
            {
                oldItem.ChangeCount(oldItem.Count + item.Count);
                return;
            }
            Items.Add(item);
        }

        public void RemoveItem(long itemId)
        {
            ChangeOrderGuard();
            var currentItem = Items.FirstOrDefault(q => q.Id == itemId);
            if (currentItem == null)
            {
                throw new NullOrEmptyDomainDataException();
            }
            Items.Remove(currentItem);
        }

        public void ChangeCountItem(int itemId, int count)
        {
            ChangeOrderGuard();
            var currentItem = Items.FirstOrDefault(q => q.Id == itemId);
            if (currentItem == null)
            {
                throw new NullOrEmptyDomainDataException();
            }
            currentItem.ChangeCount(count);
        }

        public void IncreaseItemCount(long itemId, int count)
        {
            ChangeOrderGuard();
            var currentItem = Items.FirstOrDefault(q => q.Id == itemId);
            if (currentItem == null)
            {
                throw new InvalidDomainDataException();
            }
            currentItem.IncreaseCount(count);
        }

        public void DecreaseItemCount(long itemId, int count)
        {
            ChangeOrderGuard();
            var currentItem = Items.FirstOrDefault(q => q.Id == itemId);
            if (currentItem == null)
            {
                throw new InvalidDomainDataException();
            }
            currentItem.DecreaseCount(count);
        }

        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void CheckOut(OrderAddress address)
        {
            ChangeOrderGuard();
            Address = address;
        }

        public void ChangeOrderGuard()
        {
            if (Status != OrderStatus.Pending)
            {
                throw new InvalidDomainDataException("امکان ویرایش این سفارش وجود ندارد");
            }
        }
    }
}
