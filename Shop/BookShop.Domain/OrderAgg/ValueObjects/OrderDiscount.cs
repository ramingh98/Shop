using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace BookShop.Domain.OrderAgg.ValueObjects
{
    public class OrderDiscount : ValueObject
    {
        public OrderDiscount(string title, int amount)
        {
            Title = title;
            Amount = amount;
        }

        public string Title { get; private set; }
        public int Amount { get; private set; }
    }
}
