using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.OrderAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Persistent.EF.OrderAgg
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "order");
            builder.HasIndex(q => q.UserId);
            builder.HasKey(q => q.Id);

            builder.OwnsMany(q => q.Items, option =>
            {
                option.ToTable("Items", "order");
                option.HasKey(q => q.Id);
                option.HasIndex(q => q.InventoryId);
                option.HasIndex(q => q.OrderId);
            });

            builder.OwnsOne(q => q.Address, option =>
            {
                option.HasKey(q => q.Id);
                option.ToTable("Addresses", "order");
                option.Property(q => q.Name).IsRequired().HasMaxLength(20);
                option.Property(q => q.City).IsRequired().HasMaxLength(15);
                option.Property(q => q.Shire).IsRequired().HasMaxLength(15);
                option.Property(q => q.Family).IsRequired().HasMaxLength(30);
                option.Property(q => q.PostalCode).IsRequired().HasMaxLength(15);
                option.Property(q => q.PhoneNumber).IsRequired().HasMaxLength(11);
                option.Property(q => q.NationalCode).IsRequired().HasMaxLength(10);
            });

            builder.OwnsOne(q => q.Discount, option =>
            {
                option.Property(q => q.Title).IsRequired().HasMaxLength(100);
            });

            builder.OwnsOne(q => q.ShippingMethod, option =>
            {
                option.Property(q => q.Type).IsRequired(false).HasMaxLength(100);
            });
        }
    }
}