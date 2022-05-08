using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.OrderAgg.Enums
{
    public enum OrderStatus
    {
        Pending,
        Finally,
        Shipping,
        Rejected
    }
}
