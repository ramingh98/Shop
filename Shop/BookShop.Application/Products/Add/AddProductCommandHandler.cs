using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application._Utilities;
using BookShop.Domain.ProductAgg;
using BookShop.Domain.ProductAgg.Repositories;
using BookShop.Domain.ProductAgg.Services;
using Common.Application;
using Common.Application.FileUtil.Interfaces;

namespace BookShop.Application.Products.Add
{
    public class AddProductCommandHandler : IBaseCommandHandler<AddProductCommand>
    {
        private readonly IProductDomainService _productDomainService;
        private readonly IProductRepository _productRepository;
        private readonly ILocalFileService _localFileService;

        public AddProductCommandHandler(IProductDomainService productDomainService, IProductRepository productRepository, ILocalFileService localFileService)
        {
            _productDomainService = productDomainService;
            _productRepository = productRepository;
            _localFileService = localFileService;
        }
        public async Task<OperationResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
            var product = new Product(request.Title, imageName, request.Description, request.CategoryId,
                request.SubCategoryId, request.SecondarySubCategoryId, request.Slug, request.SeoData, _productDomainService);
            _productRepository.Add(product);
            var specifications = new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(q =>
            {
                specifications.Add(new ProductSpecification(q.Key, q.Value));
            });
            product.SetSpecification(specifications);
            await _productRepository.Save();
            return OperationResult.Success();
        }
    }
}