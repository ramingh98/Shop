using System;
using BookShop.Application.Sellers.Add;
using BookShop.Application.Sellers.Edit;
using BookShop.Query.Sellers.DTOs;
using BookShop.Query.Sellers.GetByFilter;
using BookShop.Query.Sellers.GetById;
using BookShop.Query.Sellers.GetByUserId;
using Common.Application;
using MediatR;

namespace BookShop.Presentation.Facade.Sellers
{
    internal class SellerFacade : ISellerFacade
    {
        private readonly IMediator _mediator;

        public SellerFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddSellerAsync(AddSellerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditSellerAsync(EditSellerCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<SellerDto?> GetSellerByIdAsync(long sellerId)
        {
            return await _mediator.Send(new GetSellerByIdQuery(sellerId));
        }

        public async Task<SellerDto?> GetSellerByUserIdAsync(long userId)
        {
            return await _mediator.Send(new GetSellerByUserIdQuery(userId));
        }

        public async Task<SellerFilterResult> GetSellersByFilterAsync(SellerFilterParam param)
        {
            return await _mediator.Send(new GetSellerByFilterQuery(param));
        }
    }
}