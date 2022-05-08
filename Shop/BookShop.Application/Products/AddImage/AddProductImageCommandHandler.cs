using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application._Utilities;
using BookShop.Domain.ProductAgg;
using BookShop.Domain.ProductAgg.Repositories;
using Common.Application;
using Common.Application.FileUtil.Interfaces;

namespace BookShop.Application.Products.AddImage
{
    public class AddProductImageCommandHandler : IBaseCommandHandler<AddProductImageCommand>
    {
        private IProductRepository _productRepository;
        private ILocalFileService _localFileService;

        public AddProductImageCommandHandler(IProductRepository productRepository, ILocalFileService localFileService)
        {
            _productRepository = productRepository;
            _localFileService = localFileService;
        }
        public async Task<OperationResult> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetTracking(request.ProductId);
            if (product == null)
            {
                return OperationResult.NotFound();
            }
            var imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductGalleryImage);
            var productImage = new ProductImage(imageName, request.Sequence);
            product.AddImage(productImage);
            await _productRepository.Save();
            return OperationResult.Success();
        }
    }
}