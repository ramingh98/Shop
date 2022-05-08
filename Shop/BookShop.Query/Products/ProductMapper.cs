using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.ProductAgg;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Query.Products.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Query.Products
{
    public static class ProductMapper
    {
        public static ProductDto? Map(this Product? product)
        {
            if (product == null)
            {
                return null;
            }

            return new()
            {
                Id = product.Id,
                CreationDate = product.CreationDate,
                Description = product.Description,
                ImageName = product.ImageName,
                Slug = product.Slug,
                Title = product.Title,
                SeoData = product.SeoData,
                Specifications = product.Specifications.Select(q => new ProductSpecificationDto()
                {
                    Value = q.Value,
                    Key = q.Key
                }).ToList(),
                Images = product.Images.Select(q => new ProductImageDto()
                {
                    Id = q.Id,
                    CreationDate = q.CreationDate,
                    ImageName = q.ImageName,
                    ProductId = q.ProductId,
                    Sequence = q.Sequence
                }).ToList(),
                Category = new()
                {
                    Id = product.CategoryId
                },
                SubCategory = new()
                {
                    Id = product.SubCategoryId
                },
                SecondarySubCategory = product.SecondarySubCategoryId != null ? new ProductCategoryDto()
                {
                    Id = product.SecondarySubCategoryId
                } : null
            };
        }

        public static ProductFilterData MapListData(this Product product)
        {
            return new ProductFilterData()
            {
                Id = product.Id,
                CreationDate = product.CreationDate,
                ImageName = product.ImageName,
                Slug = product.Slug,
                Title = product.Title
            };
        }

        public static async Task SetCategories(this ProductDto product, ApplicationDbContext context)
        {
            var categories = await context.Categories.Where(q =>
                    q.Id == product.Category.Id || q.Id == product.SubCategory.Id || q.Id == product.SecondarySubCategory.Id)
                .Select(q => new ProductCategoryDto()
                {
                    Id = q.Id,
                    Slug = q.Slug,
                    ParentId = q.ParentId,
                    SeoData = q.SeoData,
                    Title = q.Title
                }).ToListAsync();

            if (product.SecondarySubCategory != null)
            {
                var secondarySubCategory = await context.Categories.Where(q => q.Id == product.SecondarySubCategory.Id)
                    .Select(q => new ProductCategoryDto()
                    {
                        Id = q.Id,
                        Slug = q.Slug,
                        ParentId = q.ParentId,
                        SeoData = q.SeoData,
                        Title = q.Title
                    }).FirstOrDefaultAsync();

                if (secondarySubCategory != null)
                {
                    product.SecondarySubCategory = secondarySubCategory;
                }
            }

            product.Category = categories.First(q => q.Id == product.Category.Id);
            product.SubCategory = categories.First(q => q.Id == product.SubCategory.Id);
        }
    }
}