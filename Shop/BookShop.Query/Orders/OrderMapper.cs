﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.OrderAgg;
using BookShop.Infrastructure.Persistent.Dapper;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Orders.DTOs;
using Dapper;

namespace BookShop.Query.Orders
{
    internal static class OrderMapper
    {
        public static OrderDto Map(this Order order)
        {
            return new OrderDto()
            {
                CreationDate = order.CreationDate,
                Id = order.Id,
                Status = order.Status,
                Address = order.Address,
                Discount = order.Discount,
                Items = new(),
                LastUpdate = order.LastUpdate,
                ShippingMethod = order.ShippingMethod,
                UserFullName = "",
                UserId = order.UserId,
            };
        }

        public static async Task<List<OrderItemDto>> GetOrderItems(this OrderDto orderDto, DapperContext dapperContext)
        {
            using var connection = dapperContext.CreateConnection();
            var sql = @$"SELECT s.ShopName ,o.OrderId,o.InventoryId,o.Count,o.price,
                p.Title as ProductTitle , p.Slug as ProductSlug,
                p.ImageName as ProductImageName FROM {dapperContext.OrderItems} o
                Inner Join {dapperContext.Inventories} i on o.InventoryId=i.Id
                Inner Join {dapperContext.Products} p on i.ProductId=p.Id
                Inner Join {dapperContext.Sellers} s on i.SellerId=s.Id where o.OrderId=@orderId";

            var result = await connection
                .QueryAsync<OrderItemDto>(sql, new { orderId = orderDto.Id });
            return result.ToList();
        }
        public static OrderFilterData MapFilterData(this Order order, ApplicationDbContext context)
        {
            var userFullName = context.Users
                .Where(r => r.Id == order.UserId)
                .Select(u => $"{u.Name} {u.Family}")
                .First();

            return new OrderFilterData()
            {
                Status = order.Status,
                Id = order.Id,
                CreationDate = order.CreationDate,
                City = order.Address?.City,
                ShippingType = order.ShippingMethod?.Type,
                Shire = order.Address?.Shire,
                TotalItemCount = order.ItemCount,
                TotalPrice = order.TotalPrice,
                UserFullName = userFullName,
                UserId = order.UserId
            };
        }
    }
}