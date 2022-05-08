using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Sellers.Add;
using BookShop.Application.Sellers.Edit;
using BookShop.Query.Sellers.DTOs;
using Common.Application;

namespace BookShop.Presentation.Facade.Sellers
{
    public interface ISellerFacade
    {
        Task<OperationResult> AddSellerAsync(AddSellerCommand command);
        Task<OperationResult> EditSellerAsync(EditSellerCommand command);
        Task<SellerDto?> GetSellerByIdAsync(long sellerId);
        Task<SellerDto?> GetSellerByUserIdAsync(long userId);
        Task<SellerFilterResult> GetSellersByFilterAsync(SellerFilterParam param);
    }
}