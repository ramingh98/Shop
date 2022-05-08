using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Query.Categories.DTOs;
using Common.Query;

namespace BookShop.Query.Categories.GetByParentId
{
    public record GetCategoryByParentIdQuery(long ParentId) : IQuery<List<ChildCategoryDto>>;
}
