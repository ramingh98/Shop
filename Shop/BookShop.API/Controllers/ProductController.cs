using BookShop.API.Infrastructures.Security;
using BookShop.Application.Products.Add;
using BookShop.Application.Products.AddImage;
using BookShop.Application.Products.Edit;
using BookShop.Application.Products.RemoveImage;
using BookShop.Domain.RoleAgg.Enums;
using BookShop.Presentation.Facade.Products;
using BookShop.Query.Products.DTOs;
using BookShop.Query.Products.GetById;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{
    [CheckPermission(Permission.CrudProduct)]
    public class ProductController : ApiController
    {
        private readonly IProductFacade _productFacade;

        public ProductController(IProductFacade productFacade)
        {
            _productFacade = productFacade;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<ProductFilterResult>> GetProductsByFilter([FromQuery] ProductFilterParam param)
        {
            var result = await _productFacade.GetProductsByFilterAsync(param);
            return QueryResult(result);
        }

        [AllowAnonymous]
        [HttpGet("Shop")]
        public async Task<ApiResult<ProductShopResult>> GetProductsForShop([FromQuery] ProductShopFilterParam param)
        {
            var result = await _productFacade.GetProductsForShopAsync(param);
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<ProductDto>> GetProductById(long id)
        {
            var result = await _productFacade.GetProductByIdAsync(id);
            return QueryResult(result);
        }

        [AllowAnonymous]
        [HttpGet("bySlug/{slug}")]
        public async Task<ApiResult<ProductDto?>> GetProductBySlug(string slug)
        {
            var result = await _productFacade.GetProductBySlugAsync(slug);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> AddProduct([FromForm] AddProductCommand command)
        {
            var result = await _productFacade.AddProductAsync(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditProduct([FromForm] EditProductCommand command)
        {
            var result = await _productFacade.EditProductAsync(command);
            return CommandResult(result);
        }

        [HttpPost("images")]
        public async Task<ApiResult> AddImage([FromForm] AddProductImageCommand command)
        {
            var result = await _productFacade.AddImageAsync(command);
            return CommandResult(result);
        }

        [HttpDelete("images")]
        public async Task<ApiResult> DeleteImage(DeleteProductImageCommand command)
        {
            var result = await _productFacade.DeleteImageAsync(command);
            return CommandResult(result);
        }
    }
}