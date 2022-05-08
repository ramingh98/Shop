using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.SiteEntities.Sliders.Add;
using BookShop.Application.SiteEntities.Sliders.Edit;
using BookShop.Query.SiteEntities.DTOs;
using Common.Application;

namespace BookShop.Presentation.Facade.SiteEntities.Sliders
{
    public interface ISliderFacade
    {
        Task<OperationResult> AddSliderAsync(AddSliderCommand command);
        Task<OperationResult> EditSliderAsync(EditSliderCommand command);
        Task<OperationResult> DeleteSliderAsync(long sliderId);
        Task<SliderDto?> GetSliderByIdAsync(long id);
        Task<List<SliderDto>> GetSlidersAsync();
    }
}