﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SellerAgg;
using Common.Domain.Repository;

namespace BookShop.Domain.SellerAgg.Repositories
{
    public interface ISellerRepository : IBaseRepository<Seller>
    {
        Task<InventoryResult> GetInventoryById(long id);
    }

    public class InventoryResult
    {
        public long Id { get; set; }
        public long SellerId { get; set; }
        public long ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
