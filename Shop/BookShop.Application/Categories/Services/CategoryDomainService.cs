using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CategoryAgg.Repositories;
using BookShop.Domain.CategoryAgg.Services;

namespace BookShop.Application.Categories.Services
{
    public class CategoryDomainService : ICategoryDomainService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryDomainService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public bool IsSlugExist(string slug)
        {
            return _categoryRepository.Exists(q => q.Slug == slug);
        }
    }
}