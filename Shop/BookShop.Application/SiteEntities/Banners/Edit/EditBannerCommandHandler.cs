using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application._Utilities;
using BookShop.Domain.SiteEntities.Repositories;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.SiteEntities.Banners.Edit
{
    public class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
    {
        private ILocalFileService _localFileService;
        private IBannerRepository _bannerRepository;

        public EditBannerCommandHandler(ILocalFileService localFileService, IBannerRepository bannerRepository)
        {
            _localFileService = localFileService;
            _bannerRepository = bannerRepository;
        }
        public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _bannerRepository.GetTracking(request.Id);
            if (banner == null)
            {
                return OperationResult.NotFound();
            }

            var imageName = banner.ImageName;
            var oldImage = banner.ImageName;
            if (request.ImageFile != null)
            {
                imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
            }
            banner.Edit(request.Link, imageName, request.Position);
            await _bannerRepository.Save();
            DeleteOldImage(request.ImageFile, oldImage);
            return OperationResult.Success();
        }

        private void DeleteOldImage(IFormFile? imageFile, string oldImage)
        {
            if (imageFile != null)
            {
                _localFileService.DeleteFile(Directories.BannerImages, oldImage);
            }
        }
    }
}