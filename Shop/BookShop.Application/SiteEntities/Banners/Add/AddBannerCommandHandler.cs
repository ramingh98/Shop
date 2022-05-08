using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application._Utilities;
using BookShop.Domain.SiteEntities;
using BookShop.Domain.SiteEntities.Repositories;
using Common.Application;
using Common.Application.FileUtil.Interfaces;

namespace BookShop.Application.SiteEntities.Banners.Add
{
    public class AddBannerCommandHandler : IBaseCommandHandler<AddBannerCommand>
    {
        private ILocalFileService _localFileService;
        private IBannerRepository _bannerRepository;

        public AddBannerCommandHandler(ILocalFileService localFileService, IBannerRepository bannerRepository)
        {
            _localFileService = localFileService;
            _bannerRepository = bannerRepository;
        }
        public async Task<OperationResult> Handle(AddBannerCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
            var banner = new Banner(request.Link, imageName, request.Position);
            _bannerRepository.Add(banner);
            await _bannerRepository.Save();
            return OperationResult.Success();
        }
    }
}
