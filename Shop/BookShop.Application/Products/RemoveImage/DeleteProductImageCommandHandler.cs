using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application._Utilities;
using BookShop.Domain.ProductAgg.Repositories;
using Common.Application;
using Common.Application.FileUtil.Interfaces;

namespace BookShop.Application.Products.RemoveImage
{
    public class DeleteProductImageCommandHandler : IBaseCommandHandler<DeleteProductImageCommand>
    {
        private IProductRepository _productRepository;
        private ILocalFileService _localFileService;

        public DeleteProductImageCommandHandler(IProductRepository productRepository, ILocalFileService localFileService)
        {
            _productRepository = productRepository;
            _localFileService = localFileService;
        }
        public async Task<OperationResult> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetTracking(request.ProductId);
            if (product == null)
            {
                return OperationResult.NotFound();
            }

            var imageName = product.DeleteImage(request.ImageId);
            await _productRepository.Save();
            _localFileService.DeleteFile(Directories.ProductGalleryImage, imageName);
            return OperationResult.Success();
        }
    }
}