using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application._Utilities;
using BookShop.Domain.SiteEntities.Repositories;
using Common.Application;
using Common.Application.FileUtil.Interfaces;

namespace BookShop.Application.SiteEntities.Sliders.Delete
{
    internal class DeleteSliderCommandHandler:IBaseCommandHandler<DeleteSliderCommand>
    {
        private ISliderRepository _sliderRepository;
        private ILocalFileService _fileService;

        public DeleteSliderCommandHandler(ISliderRepository sliderRepository, ILocalFileService fileService)
        {
            _sliderRepository = sliderRepository;
            _fileService = fileService;
        }
        public async Task<OperationResult> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
        {
            var slider = await _sliderRepository.GetTracking(request.Id);
            if (slider == null)
            {
                return OperationResult.NotFound();
            }

            _sliderRepository.Delete(slider);
            await _sliderRepository.Save();
            _fileService.DeleteFile(Directories.SliderImages, slider.ImageName);

            return OperationResult.Success();
        }
    }
}