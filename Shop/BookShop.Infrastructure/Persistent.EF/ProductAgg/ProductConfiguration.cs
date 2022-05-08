using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Persistent.EF.ProductAgg
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "product");
            builder.HasIndex(q => q.Slug).IsUnique();
            builder.Property(q => q.Slug).IsRequired().IsUnicode();
            builder.Property(q => q.Title).IsRequired().HasMaxLength(100);
            builder.Property(q => q.Description).IsRequired().HasMaxLength(600);
            builder.Property(q => q.ImageName).IsRequired().HasMaxLength(50);

            builder.OwnsOne(q => q.SeoData, option =>
            {
                option.Property(q => q.Schema).HasColumnName("Schema");
                option.Property(q => q.IndexPage).HasColumnName("IndexPage");
                option.Property(q => q.MetaTitle).HasColumnName("MetaTitle").HasMaxLength(300);
                option.Property(q => q.Canonical).HasColumnName("Canonical").HasMaxLength(300);
                option.Property(q => q.MetaKeyWords).HasColumnName("MetaKeyWords").HasMaxLength(300);
                option.Property(q => q.MetaDescription).HasColumnName("MetaDescription").HasMaxLength(300);
            });

            builder.OwnsMany(q => q.Specifications, option =>
            {
                option.ToTable("Specifications", "product");
                option.Property(q => q.Key).IsRequired().HasMaxLength(30);
                option.Property(q => q.Value).IsRequired().HasMaxLength(100);
            });
        }
    }
}