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

namespace BookShop.Application.SiteEntities.Sliders.Edit
{
    public class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
    {
        private ISliderRepository _sliderRepository;
        private ILocalFileService _localFileService;

        public EditSliderCommandHandler(ISliderRepository sliderRepository, ILocalFileService localFileService)
        {
            _sliderRepository = sliderRepository;
            _localFileService = localFileService;
        }
        public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
        {
            var slider = await _sliderRepository.GetTracking(request.Id);
            if (slider == null)
            {
                return OperationResult.NotFound();
            }
            var imageName = slider.ImageName;
            var oldImage = slider.ImageName;
            if (request.ImageFile != null)
            {
                await _localFileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
            }
            slider.Edit(request.Title, request.Link, imageName);
            await _sliderRepository.Save();
            DeleteOldImage(request.ImageFile, oldImage);
            return OperationResult.Success();
        }

        private void DeleteOldImage(IFormFile? imageFile, string oldImage)
        {
            if (imageFile != null)
            {
                _localFileService.DeleteFile(Directories.SliderImages, oldImage);
            }
        }
    }
}
