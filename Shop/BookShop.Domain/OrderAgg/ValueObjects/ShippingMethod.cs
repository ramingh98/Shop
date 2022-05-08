using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;

namespace BookShop.Domain.OrderAgg.ValueObjects
{
    public class ShippingMethod : ValueObject
    {
        public ShippingMethod(string type, int cost)
        {
            Type = type;
            Cost = cost;
        }

        public string Type { get; private set; }
        public int Cost { get; private set; }
    }
}
