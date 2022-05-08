using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.SellerAgg.Enums;
using BookShop.Domain.SellerAgg.Services;
using Common.Domain;
using Common.Domain.Exceptions;

namespace BookShop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public SellerStatus Status { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public List<SellerInventory> Inventories { get; private set; }

        private Seller()
        {

        }

        public Seller(long userId, string shopName, string nationalCode, ISellerDomainService domainService)
        {
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventories = new List<SellerInventory>();
            if (domainService.IsSellerInformationValid(this) == false)
            {
                throw new InvalidDomainDataException("اطلاعات نامعتبر است");
            }
        }

        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Edit(string shopName, string nationalCode, SellerStatus status, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);
            if (domainService.IsNationalCodeExist(nationalCode))
            {
                throw new InvalidDomainDataException("کدملی متعلق به شخص دیگری است");
            }
            ShopName = shopName;
            NationalCode = nationalCode;
            Status = status;
        }

        public void AddInventory(SellerInventory inventory)
        {
            if (Inventories.Any(q => q.ProductId == inventory.ProductId))
            {
                throw new InvalidDomainDataException("این محصول قبلا ثبت شده است");
            }
            Inventories.Add(inventory);
        }

        public void EditInventory(long inventoryId, int count, int price, int? discountPercentage)
        {
            var currentInventory = Inventories.FirstOrDefault(q => q.Id == inventoryId);
            if (currentInventory == null)
            {
                throw new NullOrEmptyDomainDataException("محصولی یافت نشد");
            }
            currentInventory.Edit(count, price, discountPercentage);
        }

        //public void DeleteInventory(long inventoryId)
        //{
        //    var inventory = Inventories.FirstOrDefault(q=>q.Id == inventoryId);
        //    if (inventory == null)
        //    {
        //        throw new NullOrEmptyDomainDataException("محصولی یافت نشد");
        //    }
        //    Inventories.Remove(inventory);
        //}

        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            if (NationalCodeValidation.IsValid(nationalCode) == false)
            {
                throw new InvalidDomainDataException("کد ملی معتبر وارد نمایید");
            }
        }
    }
}
