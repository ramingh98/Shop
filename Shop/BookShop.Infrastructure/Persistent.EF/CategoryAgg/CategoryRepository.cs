using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CategoryAgg;
using BookShop.Domain.CategoryAgg.Repositories;
using BookShop.Infrastructure._Utilities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Persistent.EF.CategoryAgg
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> DeleteCategory(long categoryId)
        {
            var category = await Context.Categories.Include(q => q.Children).ThenInclude(q => q.Children).FirstOrDefaultAsync(q => q.Id == categoryId);

            if (category == null)
            {
                return false;
            }

            var isProductExist = await Context.Products.AnyAsync(q => q.CategoryId == categoryId || q.SubCategoryId == categoryId || q.SecondarySubCategoryId == categoryId);

            if (isProductExist)
            {
                return false;
            }

            if (category.Children.Any(q => q.Children.Any()))
            {
                Context.RemoveRange(category.Children.SelectMany(q => q.Children));
            }

            Context.RemoveRange(category.Children);
            Context.RemoveRange(category);
            return true;
        }
    }
}