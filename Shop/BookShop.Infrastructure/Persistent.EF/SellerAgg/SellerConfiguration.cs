using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SellerAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Persistent.EF.SellerAgg
{
    internal class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Sellers", "seller");
            builder.HasIndex(t => t.NationalCode);
            builder.Property(q => q.ShopName).IsRequired().HasMaxLength(40);
            builder.Property(q => q.NationalCode).IsRequired().HasMaxLength(10);

            builder.OwnsMany(q => q.Inventories, option =>
            {
                option.ToTable("Inventories", "seller");
                option.HasKey(q=>q.Id);
                option.HasIndex(q => q.ProductId);
                option.HasIndex(q => q.SellerId);
            });
        }
    }
}