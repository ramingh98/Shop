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

namespace BookShop.Application.SiteEntities.Sliders.Add
{
    public class AddSliderCommandHandler : IBaseCommandHandler<AddSliderCommand>
    {
        private ISliderRepository _sliderRepository;
        private ILocalFileService _localFileService;

        public AddSliderCommandHandler(ISliderRepository sliderRepository, ILocalFileService localFileService)
        {
            _sliderRepository = sliderRepository;
            _localFileService = localFileService;
        }
        public async Task<OperationResult> Handle(AddSliderCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
            var slider = new Slider(request.Title, request.Link, imageName);
            _sliderRepository.Add(slider);
            await _sliderRepository.Save();
            return OperationResult.Success();
        }
    }
}
