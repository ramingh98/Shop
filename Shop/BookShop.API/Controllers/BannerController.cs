using BookShop.API.Infrastructures.Security;
using BookShop.Application.SiteEntities.Banners.Add;
using BookShop.Application.SiteEntities.Banners.Edit;
using BookShop.Domain.RoleAgg.Enums;
using BookShop.Presentation.Facade.SiteEntities.Banners;
using BookShop.Query.SiteEntities.DTOs;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{
    [CheckPermission(Permission.CrudBanner)]
    public class BannerController : ApiController
    {
        private readonly IBannerFacade _bannerFacade;

        public BannerController(IBannerFacade bannerFacade)
        {
            _bannerFacade = bannerFacade;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<List<BannerDto>>> GetBanners()
        {
            var result = await _bannerFacade.GetBannersAsync();
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<BannerDto>> GetBannerById(long id)
        {
            var result = await _bannerFacade.GetBannerByIdAsync(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> AddBanner(AddBannerCommand command)
        {
            var result = await _bannerFacade.AddBannerAsync(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditBanner(EditBannerCommand command)
        {
            var result = await _bannerFacade.EditBannerAsync(command);
            return CommandResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> DeleteBanner(long id)
        {
            var result = await _bannerFacade.DeleteBannerAsync(id);
            return CommandResult(result);
        }
    }
}