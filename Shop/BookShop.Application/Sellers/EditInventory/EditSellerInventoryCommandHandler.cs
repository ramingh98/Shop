using BookShop.Domain.SellerAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Sellers.EditInventory;

public class EditSellerInventoryCommandHandler : IBaseCommandHandler<EditSellerInventoryCommand>
{
    private ISellerRepository _sellerRepository;

    public EditSellerInventoryCommandHandler(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }
    public async Task<OperationResult> Handle(EditSellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await _sellerRepository.GetTracking(request.SellerId);
        if (seller == null)
        {
            return OperationResult.NotFound();
        }
        seller.EditInventory(request.InventoryId, request.Count, request.Price, request.DiscountPercentage);
        await _sellerRepository.Save();
        return OperationResult.Success();
    }
}