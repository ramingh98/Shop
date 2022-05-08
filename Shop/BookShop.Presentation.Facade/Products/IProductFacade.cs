using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Products.Add;
using BookShop.Application.Products.AddImage;
using BookShop.Application.Products.Edit;
using BookShop.Application.Products.RemoveImage;
using BookShop.Query.Products.DTOs;
using Common.Application;

namespace BookShop.Presentation.Facade.Products
{
    public interface IProductFacade
    {
        Task<OperationResult> AddProductAsync(AddProductCommand command);
        Task<OperationResult> EditProductAsync(EditProductCommand command);
        Task<OperationResult> AddImageAsync(AddProductImageCommand command);
        Task<OperationResult> DeleteImageAsync(DeleteProductImageCommand command);
        Task<ProductDto?> GetProductByIdAsync(long productId);
        Task<ProductDto?> GetProductBySlugAsync(string slug);
        Task<ProductFilterResult> GetProductsByFilterAsync(ProductFilterParam param);
        Task<ProductShopResult> GetProductsForShopAsync(ProductShopFilterParam param);
    }
}