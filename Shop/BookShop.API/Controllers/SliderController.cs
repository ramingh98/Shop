using BookShop.API.Infrastructures.Security;
using BookShop.Application.SiteEntities.Sliders.Add;
using BookShop.Application.SiteEntities.Sliders.Edit;
using BookShop.Domain.RoleAgg.Enums;
using BookShop.Presentation.Facade.SiteEntities.Sliders;
using BookShop.Query.SiteEntities.DTOs;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{
    [CheckPermission(Permission.CrudSlider)]
    public class SliderController : ApiController
    {
        private readonly ISliderFacade _sliderFacade;

        public SliderController(ISliderFacade sliderFacade)
        {
            _sliderFacade = sliderFacade;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<List<SliderDto>>> GetSliders()
        {
            var result = await _sliderFacade.GetSlidersAsync();
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<SliderDto?>> GetSliderById(long id)
        {
            var result = await _sliderFacade.GetSliderByIdAsync(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> AddSlider([FromForm] AddSliderCommand command)
        {
            var result = await _sliderFacade.AddSliderAsync(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditSlider([FromForm] EditSliderCommand command)
        {
            var result = await _sliderFacade.EditSliderAsync(command);
            return CommandResult(result);
        }

        [HttpDelete("{sliderId}")]
        public async Task<ApiResult> DeleteSlider(long sliderId)
        {
            var result = await _sliderFacade.DeleteSliderAsync(sliderId);
            return CommandResult(result);
        }
    }
}