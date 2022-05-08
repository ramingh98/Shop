using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SellerAgg.Repositories;
using BookShop.Domain.SellerAgg.Services;
using Common.Application;

namespace BookShop.Application.Sellers.Edit
{
    public class EditSellerCommandHandler : IBaseCommandHandler<EditSellerCommand>
    {
        private readonly ISellerDomainService _sellerDomainService;
        private readonly ISellerRepository _sellerRepository;

        public EditSellerCommandHandler(ISellerDomainService sellerDomainService, ISellerRepository sellerRepository)
        {
            _sellerDomainService = sellerDomainService;
            _sellerRepository = sellerRepository;
        }
        public async Task<OperationResult> Handle(EditSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = await _sellerRepository.GetTracking(request.Id);
            if (seller == null)
            {
                return OperationResult.NotFound();
            }
            seller.Edit(request.ShopName, request.NationalCode, request.Status, _sellerDomainService);
            await _sellerRepository.Save();
            return OperationResult.Success();
        }
    }
}
