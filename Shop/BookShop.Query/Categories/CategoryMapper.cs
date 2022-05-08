using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CategoryAgg;
using BookShop.Query.Categories.DTOs;

namespace BookShop.Query.Categories
{
    internal static class CategoryMapper
    {
        public static CategoryDto Map(this Category? category)
        {
            if (category == null)
            {
                return null;
            }

            return new CategoryDto()
            {
                Id = category.Id,
                Slug = category.Slug,
                Title = category.Title,
                SeoData = category.SeoData,
                CreationDate = category.CreationDate,
                Children = category.Children.MapChildren()
            };
        }

        public static List<CategoryDto> Map(this List<Category> categories)
        {
            var model = new List<CategoryDto>();
            categories.ForEach(q =>
            {
                model.Add(new CategoryDto()
                {
                    Id = q.Id,
                    Slug = q.Slug,
                    Title = q.Title,
                    SeoData = q.SeoData,
                    CreationDate = q.CreationDate,
                    Children = q.Children.MapChildren()
                });
            });
            return model;
        }

        public static List<ChildCategoryDto> MapChildren(this List<Category> children)
        {
            var model = new List<ChildCategoryDto>();

            children.ForEach(c =>
            {
                model.Add(new ChildCategoryDto()
                {
                    Title = c.Title,
                    Slug = c.Slug,
                    Id = c.Id,
                    SeoData = c.SeoData,
                    CreationDate = c.CreationDate,
                    ParentId = (long)c.ParentId,
                    Children = c.Children.MapSecondaryChild()
                });
            });
            return model;
        }

        private static List<SecondaryChildCategoryDto> MapSecondaryChild(this List<Category> children)
        {
            var model = new List<SecondaryChildCategoryDto>();
            children.ForEach(q =>
            {
                model.Add(new SecondaryChildCategoryDto()
                {
                    Title = q.Title,
                    Slug = q.Slug,
                    Id = q.Id,
                    SeoData = q.SeoData,
                    CreationDate = q.CreationDate,
                    ParentId = (long)q.ParentId,
                });
            });
            return model;
        }
    }
}