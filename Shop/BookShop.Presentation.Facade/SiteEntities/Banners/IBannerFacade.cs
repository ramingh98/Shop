using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.SiteEntities.Banners.Add;
using BookShop.Application.SiteEntities.Banners.Edit;
using BookShop.Query.SiteEntities.DTOs;
using Common.Application;

namespace BookShop.Presentation.Facade.SiteEntities.Banners
{
    public interface IBannerFacade
    {
        Task<OperationResult> AddBannerAsync(AddBannerCommand command);
        Task<OperationResult> EditBannerAsync(EditBannerCommand command);
        Task<OperationResult> DeleteBannerAsync(long bannerId);
        Task<BannerDto?> GetBannerByIdAsync(long id);
        Task<List<BannerDto>> GetBannersAsync();
    }
}