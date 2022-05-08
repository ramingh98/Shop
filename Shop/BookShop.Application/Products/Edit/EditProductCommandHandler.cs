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
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.Products.Edit
{
    public class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
    {
        private IProductDomainService _productDomainService;
        private IProductRepository _productRepository;
        private ILocalFileService _localFileService;

        public EditProductCommandHandler(IProductDomainService productDomainService, IProductRepository productRepository, ILocalFileService localFileService)
        {
            _productDomainService = productDomainService;
            _productRepository = productRepository;
            _localFileService = localFileService;
        }
        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetTracking(request.ProductId);
            if (product == null)
            {
                return OperationResult.NotFound();
            }
            product.Edit(request.Title, request.Description, request.CategoryId, request.SubCategoryId, request.SecondarySubCategoryId, request.Slug, request.SeoData, _productDomainService);
            var oldImage = product.ImageName;
            if (request.ImageFile != null)
            {
                var imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
                product.SetProductImage(imageName);
            }

            var specifications = new List<ProductSpecification>();
            request.Specifications.ToList().ForEach(q =>
            {
                specifications.Add(new ProductSpecification(q.Key, q.Value));
            });
            product.SetSpecification(specifications);
            await _productRepository.Save();
            RemoveOldImage(request.ImageFile, oldImage);
            return OperationResult.Success();
        }

        private void RemoveOldImage(IFormFile imageFile, string oldImageName)
        {
            if (imageFile != null)
            {
                _localFileService.DeleteFile(Directories.ProductImages, oldImageName);
            }
        }
    }
}