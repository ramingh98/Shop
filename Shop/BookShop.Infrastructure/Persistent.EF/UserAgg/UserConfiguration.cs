using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Persistent.EF.UserAgg
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "user");
            builder.HasIndex(q => q.PhoneNumber).IsUnique();
            builder.HasIndex(q => q.Email).IsUnique();
            builder.Property(q => q.Name).IsRequired(false).HasMaxLength(30);
            builder.Property(q => q.Family).IsRequired(false).HasMaxLength(40);
            builder.Property(q => q.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(q => q.Email).IsRequired(false).HasMaxLength(256);
            builder.Property(q => q.Password).IsRequired().HasMaxLength(50);

            builder.OwnsMany(q => q.Tokens, option =>
            {
                option.HasKey(q => q.Id);
                option.ToTable("Tokens", "user");
                option.Property(q => q.Device).IsRequired().HasMaxLength(100);
                option.Property(q => q.HashJwtToken).IsRequired().HasMaxLength(250);
                option.Property(q => q.HashRefreshToken).IsRequired().HasMaxLength(250);
            });

            builder.OwnsMany(q => q.Addresses, option =>
            {
                option.HasIndex(q => q.UserId);
                option.ToTable("Addresses", "user");
                option.Property(q => q.Name).IsRequired().HasMaxLength(50);
                option.Property(q => q.City).IsRequired().HasMaxLength(15);
                option.Property(q => q.Shire).IsRequired().HasMaxLength(15);
                option.Property(q => q.Family).IsRequired().HasMaxLength(50);
                option.Property(q => q.PostalCode).IsRequired().HasMaxLength(10);
                option.Property(q => q.NationalCode).IsRequired().HasMaxLength(10);
                option.OwnsOne(q => q.PhoneNumber, config =>
                {
                    config.Property(q => q.Value).HasColumnName("PhoneNumber").IsRequired().HasMaxLength(11);
                });
            });

            builder.OwnsMany(q => q.Wallets, option =>
            {
                option.ToTable("Wallet", "user");
                option.HasIndex(q => q.UserId);
                option.Property(q => q.Description).IsRequired(false).HasMaxLength(300);
            });

            builder.OwnsMany(q => q.Roles, option =>
            {
                option.ToTable("Roles", "user");
                option.HasIndex(q => q.UserId);
            });
        }
    }
}