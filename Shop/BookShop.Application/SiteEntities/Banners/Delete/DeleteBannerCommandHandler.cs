using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application._Utilities;
using BookShop.Domain.SiteEntities.Repositories;
using Common.Application;
using Common.Application.FileUtil.Interfaces;

namespace BookShop.Application.SiteEntities.Banners.Delete
{
    internal class DeleteBannerCommandHandler : IBaseCommandHandler<DeleteBannerCommand>
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly ILocalFileService _fileService;

        public DeleteBannerCommandHandler(IBannerRepository bannerRepository, ILocalFileService fileService)
        {
            _bannerRepository = bannerRepository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _bannerRepository.GetTracking(request.Id);
            if (banner == null)
            {
                return OperationResult.NotFound();
            }

            _bannerRepository.Delete(banner);
            await _bannerRepository.Save();
            _fileService.DeleteFile(Directories.BannerImages, banner.ImageName);

            return OperationResult.Success();
        }
    }
}