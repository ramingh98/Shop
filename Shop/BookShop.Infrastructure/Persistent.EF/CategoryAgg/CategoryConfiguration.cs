using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Persistent.EF.CategoryAgg
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "dbo");
            builder.HasKey(q => q.Id);
            builder.HasIndex(q => q.Slug);
            builder.Property(q => q.Slug).IsRequired().IsUnicode(false);
            builder.Property(q => q.Title).IsRequired();

            builder.HasMany(q => q.Children).WithOne().HasForeignKey(q => q.ParentId);

            builder.OwnsOne(q => q.SeoData, option =>
            {
                option.Property(q => q.Schema).HasColumnName("Schema");
                option.Property(q => q.IndexPage).HasColumnName("IndexPage");
                option.Property(q => q.Canonical).HasColumnName("Canonical").HasMaxLength(100);
                option.Property(q => q.MetaTitle).HasColumnName("MetaTitle").HasMaxLength(100);
                option.Property(q => q.MetaKeyWords).HasColumnName("MetaKeyWords").HasMaxLength(300);
                option.Property(q => q.MetaDescription).HasColumnName("MetaDescription").HasMaxLength(300);
            });
        }
    }
}