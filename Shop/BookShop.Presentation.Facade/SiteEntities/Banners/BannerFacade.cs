using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.SiteEntities.Banners.Add;
using BookShop.Application.SiteEntities.Banners.Delete;
using BookShop.Application.SiteEntities.Banners.Edit;
using BookShop.Query.SiteEntities.Banners.GetById;
using BookShop.Query.SiteEntities.Banners.GetList;
using BookShop.Query.SiteEntities.DTOs;
using Common.Application;
using MediatR;

namespace BookShop.Presentation.Facade.SiteEntities.Banners
{
    internal class BannerFacade : IBannerFacade
    {
        private readonly IMediator _mediator;

        public BannerFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddBannerAsync(AddBannerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditBannerAsync(EditBannerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteBannerAsync(long bannerId)
        {
            return await _mediator.Send(new DeleteBannerCommand(bannerId));
        }

        public async Task<BannerDto?> GetBannerByIdAsync(long id)
        {
            return await _mediator.Send(new GetBannerByIdQuery(id));
        }

        public async Task<List<BannerDto>> GetBannersAsync()
        {
            return await _mediator.Send(new GetBannerListQuery());
        }
    }
}