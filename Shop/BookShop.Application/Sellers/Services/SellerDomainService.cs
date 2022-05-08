using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SellerAgg;
using BookShop.Domain.SellerAgg.Repositories;
using BookShop.Domain.SellerAgg.Services;

namespace BookShop.Application.Sellers.Services
{
    public class SellerDomainService : ISellerDomainService
    {
        private ISellerRepository _sellerRepository;

        public SellerDomainService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public bool IsSellerInformationValid(Seller seller)
        {
            return !_sellerRepository.Exists(q => q.NationalCode == seller.NationalCode || q.UserId == seller.UserId);
        }

        public bool IsNationalCodeExist(string nationalCode)
        {
            return _sellerRepository.Exists(q => q.NationalCode == nationalCode);
        }
    }
}