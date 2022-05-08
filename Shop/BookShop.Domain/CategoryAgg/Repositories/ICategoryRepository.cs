using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Repository;

namespace BookShop.Domain.CategoryAgg.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<bool> DeleteCategory(long categoryId);
    }
}
