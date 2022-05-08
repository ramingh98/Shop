﻿// <auto-generated />
using System;
using BookShop.Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookShop.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220503152625_20220503-1955")]
    partial class _202205031955
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookShop.Domain.CategoryAgg.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(900)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("Slug");

                    b.ToTable("Categories", "dbo");
                });

            modelBuilder.Entity("BookShop.Domain.CommentAgg.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BookShop.Domain.OrderAgg.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders", "order");
                });

            modelBuilder.Entity("BookShop.Domain.ProductAgg.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("SecondarySubCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("SubCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Products", "product");
                });

            modelBuilder.Entity("BookShop.Domain.ProductAgg.ProductImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImage");
                });

            modelBuilder.Entity("BookShop.Domain.RoleAgg.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Roles", "role");
                });

            modelBuilder.Entity("BookShop.Domain.SellerAgg.Seller", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("NationalCode");

                    b.ToTable("Sellers", "seller");
                });

            modelBuilder.Entity("BookShop.Domain.SiteEntities.Banner", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("BookShop.Domain.SiteEntities.Slider", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("BookShop.Domain.UserAgg.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("AvatarName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Family")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Users", "user");
                });

            modelBuilder.Entity("BookShop.Domain.CategoryAgg.Category", b =>
                {
                    b.HasOne("BookShop.Domain.CategoryAgg.Category", null)
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.OwnsOne("Common.Domain.ValueObjects.SeoData", "SeoData", b1 =>
                        {
                            b1.Property<long>("CategoryId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Canonical")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Canonical");

                            b1.Property<bool>("IndexPage")
                                .HasColumnType("bit")
                                .HasColumnName("IndexPage");

                            b1.Property<string>("MetaDescription")
                                .IsRequired()
                                .HasMaxLength(300)
                                .HasColumnType("nvarchar(300)")
                                .HasColumnName("MetaDescription");

                            b1.Property<string>("MetaKeyWords")
                                .IsRequired()
                                .HasMaxLength(300)
                                .HasColumnType("nvarchar(300)")
                                .HasColumnName("MetaKeyWords");

                            b1.Property<string>("MetaTitle")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("MetaTitle");

                            b1.Property<string>("Schema")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Schema");

                            b1.HasKey("CategoryId");

                            b1.ToTable("Categories", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("CategoryId");
                        });

                    b.Navigation("SeoData")
                        .IsRequired();
                });

            modelBuilder.Entity("BookShop.Domain.OrderAgg.Order", b =>
                {
                    b.OwnsOne("BookShop.Domain.OrderAgg.OrderAddress", "Address", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("nvarchar(15)");

                            b1.Property<string>("Family")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar(30)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.Property<string>("NationalCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)");

                            b1.Property<string>("PostalAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("nvarchar(15)");

                            b1.Property<string>("Shire")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("nvarchar(15)");

                            b1.HasKey("Id");

                            b1.HasIndex("OrderId")
                                .IsUnique();

                            b1.ToTable("Addresses", "order");

                            b1.WithOwner("Order")
                                .HasForeignKey("OrderId");

                            b1.Navigation("Order");
                        });

                    b.OwnsMany("BookShop.Domain.OrderAgg.OrderItem", "Items", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<int>("Count")
                                .HasColumnType("int");

                            b1.Property<long>("InventoryId")
                                .HasColumnType("bigint");

                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Price")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("InventoryId");

                            b1.HasIndex("OrderId");

                            b1.ToTable("Items", "order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("BookShop.Domain.OrderAgg.ValueObjects.OrderDiscount", "Discount", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Amount")
                                .HasColumnType("int");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders", "order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("BookShop.Domain.OrderAgg.ValueObjects.ShippingMethod", "ShippingMethod", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Cost")
                                .HasColumnType("int");

                            b1.Property<string>("Type")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders", "order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Discount");

                    b.Navigation("Items");

                    b.Navigation("ShippingMethod");
                });

            modelBuilder.Entity("BookShop.Domain.ProductAgg.Product", b =>
                {
                    b.OwnsOne("Common.Domain.ValueObjects.SeoData", "SeoData", b1 =>
                        {
                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Canonical")
                                .IsRequired()
                                .HasMaxLength(300)
                                .HasColumnType("nvarchar(300)")
                                .HasColumnName("Canonical");

                            b1.Property<bool>("IndexPage")
                                .HasColumnType("bit")
                                .HasColumnName("IndexPage");

                            b1.Property<string>("MetaDescription")
                                .IsRequired()
                                .HasMaxLength(300)
                                .HasColumnType("nvarchar(300)")
                                .HasColumnName("MetaDescription");

                            b1.Property<string>("MetaKeyWords")
                                .IsRequired()
                                .HasMaxLength(300)
                                .HasColumnType("nvarchar(300)")
                                .HasColumnName("MetaKeyWords");

                            b1.Property<string>("MetaTitle")
                                .IsRequired()
                                .HasMaxLength(300)
                                .HasColumnType("nvarchar(300)")
                                .HasColumnName("MetaTitle");

                            b1.Property<string>("Schema")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Schema");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products", "product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsMany("BookShop.Domain.ProductAgg.ProductSpecification", "Specifications", b1 =>
                        {
                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<string>("Key")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar(30)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("ProductId", "Id");

                            b1.ToTable("Specifications", "product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("SeoData")
                        .IsRequired();

                    b.Navigation("Specifications");
                });

            modelBuilder.Entity("BookShop.Domain.ProductAgg.ProductImage", b =>
                {
                    b.HasOne("BookShop.Domain.ProductAgg.Product", null)
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookShop.Domain.RoleAgg.Role", b =>
                {
                    b.OwnsMany("BookShop.Domain.RoleAgg.RolePermission", "Permissions", b1 =>
                        {
                            b1.Property<long>("RoleId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<int>("Permission")
                                .HasColumnType("int");

                            b1.HasKey("RoleId", "Id");

                            b1.ToTable("Permissions", "role");

                            b1.WithOwner()
                                .HasForeignKey("RoleId");
                        });

                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("BookShop.Domain.SellerAgg.Seller", b =>
                {
                    b.OwnsMany("BookShop.Domain.SellerAgg.SellerInventory", "Inventories", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<int>("Count")
                                .HasColumnType("int");

                            b1.Property<int?>("DiscountPercentage")
                                .HasColumnType("int");

                            b1.Property<int>("Price")
                                .HasColumnType("int");

                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<long>("SellerId")
                                .HasColumnType("bigint");

                            b1.HasKey("Id");

                            b1.HasIndex("ProductId");

                            b1.HasIndex("SellerId");

                            b1.ToTable("Inventories", "seller");

                            b1.WithOwner()
                                .HasForeignKey("SellerId");
                        });

                    b.Navigation("Inventories");
                });

            modelBuilder.Entity("BookShop.Domain.UserAgg.User", b =>
                {
                    b.OwnsMany("BookShop.Domain.UserAgg.UserAddress", "Addresses", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<bool>("ActiveAddress")
                                .HasColumnType("bit");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("nvarchar(15)");

                            b1.Property<string>("Family")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("NationalCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("PostalAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("Shire")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("nvarchar(15)");

                            b1.HasKey("UserId", "Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("Addresses", "user");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.OwnsOne("Common.Domain.ValueObjects.PhoneNumber", "PhoneNumber", b2 =>
                                {
                                    b2.Property<long>("UserAddressUserId")
                                        .HasColumnType("bigint");

                                    b2.Property<long>("UserAddressId")
                                        .HasColumnType("bigint");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(11)
                                        .HasColumnType("nvarchar(11)")
                                        .HasColumnName("PhoneNumber");

                                    b2.HasKey("UserAddressUserId", "UserAddressId");

                                    b2.ToTable("Addresses", "user");

                                    b2.WithOwner()
                                        .HasForeignKey("UserAddressUserId", "UserAddressId");
                                });

                            b1.Navigation("PhoneNumber")
                                .IsRequired();
                        });

                    b.OwnsMany("BookShop.Domain.UserAgg.UserRole", "Roles", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<long>("RoleId")
                                .HasColumnType("bigint");

                            b1.HasKey("UserId", "Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("Roles", "user");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsMany("BookShop.Domain.UserAgg.Wallet", "Wallets", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"), 1L, 1);

                            b1.Property<string>("Description")
                                .HasMaxLength(300)
                                .HasColumnType("nvarchar(300)");

                            b1.Property<DateTime?>("FinallyDate")
                                .HasColumnType("datetime2");

                            b1.Property<bool>("IsFinally")
                                .HasColumnType("bit");

                            b1.Property<int>("Price")
                                .HasColumnType("int");

                            b1.Property<int>("Type")
                                .HasColumnType("int");

                            b1.HasKey("UserId", "Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("Wallet", "user");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Addresses");

                    b.Navigation("Roles");

                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("BookShop.Domain.CategoryAgg.Category", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("BookShop.Domain.ProductAgg.Product", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
