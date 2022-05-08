using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SiteEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Persistent.EF.SiteEntities
{
    internal class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(q => q.Link).HasMaxLength(300).IsRequired();
            builder.Property(q => q.Title).HasMaxLength(100).IsRequired();
            builder.Property(q => q.ImageName).HasMaxLength(120).IsRequired();
        }
    }
}