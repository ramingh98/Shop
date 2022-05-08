using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Products.AddImage;
using BookShop.Application.Products.Add;
using BookShop.Application.Products.Edit;
using BookShop.Application.Products.RemoveImage;
using BookShop.Query.Products.DTOs;
using BookShop.Query.Products.GetByFilter;
using BookShop.Query.Products.GetById;
using BookShop.Query.Products.GetBySlug;
using BookShop.Query.Products.GetForShop;
using Common.Application;
using MediatR;

namespace BookShop.Presentation.Facade.Products
{
    internal class ProductFacade : IProductFacade
    {
        private readonly IMediator _mediator;

        public ProductFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddProductAsync(AddProductCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditProductAsync(EditProductCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> AddImageAsync(AddProductImageCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteImageAsync(DeleteProductImageCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<ProductDto?> GetProductByIdAsync(long productId)
        {
            return await _mediator.Send(new GetProductsByIdQuery(productId));
        }

        public async Task<ProductDto?> GetProductBySlugAsync(string slug)
        {
            return await _mediator.Send(new GetProductBySlugQuery(slug));
        }

        public async Task<ProductFilterResult> GetProductsByFilterAsync(ProductFilterParam param)
        {
            return await _mediator.Send(new GetProductsByFilterQuery(param));
        }

        public async Task<ProductShopResult> GetProductsForShopAsync(ProductShopFilterParam param)
        {
            return await _mediator.Send(new GetProductForShopQuery(param));
        }
    }
}