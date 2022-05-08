using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.SiteEntities.Sliders.Add;
using BookShop.Application.SiteEntities.Sliders.Delete;
using BookShop.Application.SiteEntities.Sliders.Edit;
using BookShop.Query.SiteEntities.DTOs;
using BookShop.Query.SiteEntities.Sliders.GetById;
using BookShop.Query.SiteEntities.Sliders.GetList;
using Common.Application;
using MediatR;

namespace BookShop.Presentation.Facade.SiteEntities.Sliders
{
    internal class SliderFacade : ISliderFacade
    {
        private readonly IMediator _mediator;

        public SliderFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddSliderAsync(AddSliderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditSliderAsync(EditSliderCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteSliderAsync(long sliderId)
        {
            return await _mediator.Send(new DeleteSliderCommand(sliderId));
        }

        public async Task<SliderDto?> GetSliderByIdAsync(long id)
        {
            return await _mediator.Send(new GetSliderByIdQuery(id));
        }

        public async Task<List<SliderDto>> GetSlidersAsync()
        {
            return await _mediator.Send(new GetSliderListQuery());
        }
    }
}