using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Sellers.AddInventory;
using BookShop.Application.Sellers.EditInventory;
using BookShop.Query.Sellers.DTOs;
using Common.Application;

namespace BookShop.Presentation.Facade.Sellers.Inventories
{
    public interface ISellerInventoryFacade
    {
        Task<OperationResult> AddInventoryAsync(AddSellerInventoryCommand command);
        Task<OperationResult> EditInventoryAsync(EditSellerInventoryCommand command);
        Task<InventoryDto?> GetByIdAsync(long inventoryId);
        Task<List<InventoryDto>> GetListAsync(long sellerId);
    }
}