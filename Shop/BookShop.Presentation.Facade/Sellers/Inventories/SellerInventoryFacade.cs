using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Sellers.AddInventory;
using BookShop.Application.Sellers.EditInventory;
using BookShop.Query.Sellers.DTOs;
using BookShop.Query.Sellers.Inventories.GetById;
using BookShop.Query.Sellers.Inventories.GetList;
using Common.Application;
using MediatR;

namespace BookShop.Presentation.Facade.Sellers.Inventories
{
    internal class SellerInventoryFacade : ISellerInventoryFacade
    {
        private readonly IMediator _mediator;

        public SellerInventoryFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddInventoryAsync(AddSellerInventoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditInventoryAsync(EditSellerInventoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<InventoryDto?> GetByIdAsync(long inventoryId)
        {
            return await _mediator.Send(new GetInventoryByIdQuery(inventoryId));
        }

        public async Task<List<InventoryDto>> GetListAsync(long sellerId)
        {
            return await _mediator.Send(new GetInventoryListQuery(sellerId));
        }
    }
}