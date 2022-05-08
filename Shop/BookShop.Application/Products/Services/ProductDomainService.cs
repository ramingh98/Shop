using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.ProductAgg.Repositories;
using BookShop.Domain.ProductAgg.Services;

namespace BookShop.Application.Products.Services
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IProductRepository _productRepository;

        public ProductDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool IsSlugExist(string slug)
        {
            return _productRepository.Exists(q => q.Slug == slug);
        }
    }
}