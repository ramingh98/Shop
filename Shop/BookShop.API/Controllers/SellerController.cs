using BookShop.API.Infrastructures.Security;
using BookShop.Application.Sellers.Add;
using BookShop.Application.Sellers.AddInventory;
using BookShop.Application.Sellers.Edit;
using BookShop.Application.Sellers.EditInventory;
using BookShop.Domain.RoleAgg.Enums;
using BookShop.Presentation.Facade.Sellers;
using BookShop.Presentation.Facade.Sellers.Inventories;
using BookShop.Query.Sellers.DTOs;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{
    public class SellerController : ApiController
    {
        private readonly ISellerFacade _sellerFacade;
        private readonly ISellerInventoryFacade _sellerInventoryFacade;
        public SellerController(ISellerFacade sellerFacade, ISellerInventoryFacade sellerInventoryFacade)
        {
            _sellerFacade = sellerFacade;
            _sellerInventoryFacade = sellerInventoryFacade;
        }

        [CheckPermission(Permission.SellerManagement)]
        [HttpGet]
        public async Task<ApiResult<SellerFilterResult>> GetSellers(SellerFilterParam filterParams)
        {
            var result = await _sellerFacade.GetSellersByFilterAsync(filterParams);
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<SellerDto?>> GetSellerById(long id)
        {
            var result = await _sellerFacade.GetSellerByIdAsync(id);
            return QueryResult(result);
        }

        [Authorize]
        [HttpGet("current")]
        public async Task<ApiResult<SellerDto?>> GetSeller()
        {
            var result = await _sellerFacade.GetSellerByUserIdAsync(User.GetUserId());
            return QueryResult(result);
        }

        [CheckPermission(Permission.SellerManagement)]
        [HttpPost]
        public async Task<ApiResult> AddSeller(AddSellerCommand command)
        {
            var result = await _sellerFacade.AddSellerAsync(command);
            return CommandResult(result);
        }

        [CheckPermission(Permission.SellerManagement)]
        [HttpPut]
        public async Task<ApiResult> EditSeller(EditSellerCommand command)
        {
            var result = await _sellerFacade.EditSellerAsync(command);
            return CommandResult(result);
        }

        [CheckPermission(Permission.AddInventory)]
        [HttpPost("inventory")]
        public async Task<ApiResult> AddInventory(AddSellerInventoryCommand command)
        {
            var result = await _sellerInventoryFacade.AddInventoryAsync(command);
            return CommandResult(result);
        }

        [CheckPermission(Permission.EditInventory)]
        [HttpPut("inventory")]
        public async Task<ApiResult> EditInventory(EditSellerInventoryCommand command)
        {
            var result = await _sellerInventoryFacade.EditInventoryAsync(command);
            return CommandResult(result);
        }

        [CheckPermission(Permission.SellerPanel)]
        [HttpGet("inventory")]
        public async Task<ApiResult<List<InventoryDto>>> GetInventories()
        {
            var seller = await _sellerFacade.GetSellerByUserIdAsync(User.GetUserId());
            if (seller == null)
            {
                return QueryResult(new List<InventoryDto>());
            }

            var result = await _sellerInventoryFacade.GetListAsync(seller.Id);
            return QueryResult(result);
        }

        [CheckPermission(Permission.SellerPanel)]
        [HttpGet("inventory/{inventoryId}")]
        public async Task<ApiResult<InventoryDto>> GetInventories(long inventoryId)
        {
            var seller = await _sellerFacade.GetSellerByUserIdAsync(User.GetUserId());
            if (seller == null)
                return QueryResult(new InventoryDto());

            var result = await _sellerInventoryFacade.GetByIdAsync(inventoryId);

            if (result == null || result.SellerId != seller.Id)
                return QueryResult(new InventoryDto());

            return QueryResult(result);
        }
    }
}