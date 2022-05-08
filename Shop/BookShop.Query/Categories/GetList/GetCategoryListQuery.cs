using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Categories.DTOs;
using Common.Query;

namespace BookShop.Query.Categories.GetList
{
    public record GetCategoryListQuery : IQuery<List<CategoryDto>>;
}
