using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Sellers.DTOs;
using Common.Query;

namespace BookShop.Query.Sellers.GetById
{
    public class GetSellerByIdQuery : IQuery<SellerDto>
    {
        public GetSellerByIdQuery(long id)
        {
            Id = id;
        }
        public long Id { get; private set; }
    }
}