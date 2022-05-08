using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SellerAgg;
using BookShop.Domain.SellerAgg.Repositories;
using BookShop.Domain.SellerAgg.Services;
using Common.Application;

namespace BookShop.Application.Sellers.Add
{
    public class AddSellerCommandHandler : IBaseCommandHandler<AddSellerCommand>
    {
        private readonly ISellerDomainService _sellerDomainService;
        private readonly ISellerRepository _sellerRepository;

        public AddSellerCommandHandler(ISellerDomainService sellerDomainService, ISellerRepository sellerRepository)
        {
            _sellerDomainService = sellerDomainService;
            _sellerRepository = sellerRepository;
        }
        public async Task<OperationResult> Handle(AddSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = new Seller(request.UserId, request.ShopName, request.NationalCode, _sellerDomainService);
            _sellerRepository.Add(seller);
            await _sellerRepository.Save();
            return OperationResult.Success();
        }
    }
}
