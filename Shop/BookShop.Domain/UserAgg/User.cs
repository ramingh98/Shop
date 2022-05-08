using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.UserAgg.Enums;
using BookShop.Domain.UserAgg.Services;
using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;

namespace BookShop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        private User()
        {

        }
        public User(string name, string family, string phoneNumber, string email, string password, Gender gender, IUserDomainService domainService)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            IsActive = true;
            Gender = gender;
            AvatarName = "avatar.png";
            Roles = new();
            Wallets = new();
            Addresses = new();
            Tokens = new();
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string AvatarName { get; set; }
        public bool IsActive { get; set; }
        public Gender Gender { get; private set; }
        public List<UserRole> Roles { get; }
        public List<Wallet> Wallets { get; }
        public List<UserAddress> Addresses { get; }
        public List<UserToken> Tokens { get; }

        public static User RegisterUser(string phoneNumber, string password, IUserDomainService domainService)
        {
            return new User("", "", phoneNumber, null, password, Gender.None, domainService);
        }

        public void Edit(string name, string family, string phoneNumber, string email, Gender gender, IUserDomainService domainService)
        {
            Guard(email, phoneNumber, domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }

        public void Guard(string email, string phoneNumber, IUserDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));

            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException("شماره موبایل نامعتبر است");

            if (!string.IsNullOrWhiteSpace(email))
                if (email.IsValidEmail() == false)
                    throw new InvalidDomainDataException(" ایمیل  نامعتبر است");

            if (phoneNumber != PhoneNumber)
                if (domainService.IsPhoneNumberExist(phoneNumber))
                    throw new InvalidDomainDataException("شماره موبایل تکراری است");

            if (email != Email)
                if (domainService.IsEmailExist(email))
                    throw new InvalidDomainDataException("ایمیل تکراری است");
        }

        public void AddAddress(UserAddress userAddress)
        {
            userAddress.UserId = Id;
            Addresses.Add(userAddress);
        }

        public void EditAddress(UserAddress userAddress, long addressId)
        {
            var address = Addresses.FirstOrDefault(q => q.Id == addressId);
            if (address == null)
            {
                throw new NullOrEmptyDomainDataException("آدرس مورد نظر یافت نشد");
            }

            address.Edit(address.Shire, address.City, address.PostalCode, address.PostalAddress, address.PhoneNumber, address.Name, address.Family, address.NationalCode);
        }

        public void DeleteAddress(long addressId)
        {
            var address = Addresses.FirstOrDefault(q => q.Id == addressId);
            if (address == null)
            {
                throw new NullOrEmptyDomainDataException("آدرس مورد نظر یافت نشد");
            }

            Addresses.Remove(address);
        }

        public void ChargeWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }

        public void SetRole(List<UserRole> userRole)
        {
            userRole.ForEach(q => q.UserId = Id);
            Roles.Clear();
            Roles.AddRange(userRole);
        }

        public void AddToken(string hashJwtToken, string hashRefreshToken, DateTime jwtTokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            var activeToken = Tokens.Count(q => q.RefreshTokenExpireDate > DateTime.Now);
            if (activeToken == 2)
            {
                throw new InvalidDomainDataException("امکان اتصال همزمان به بیش از 2 دستگاه وجود ندارد");
            }

            var token = new UserToken(hashJwtToken, hashRefreshToken, jwtTokenExpireDate, refreshTokenExpireDate, device);
            token.UserId = Id;
            Tokens.Add(token);
        }

        public void DeleteToken(long id)
        {
            var token = Tokens.FirstOrDefault(q => q.Id == id);
            if (token == null)
            {
                throw new NullOrEmptyDomainDataException("شناسه نامعتبر میباشد");
            }

            Tokens.Remove(token);
        }

        public void ChangePassword(string newPassword)
        {
            NullOrEmptyDomainDataException.CheckString(newPassword, nameof(newPassword));
            Password = newPassword;
        }

        public void SetAvatar(string avatar)
        {
            if (string.IsNullOrWhiteSpace(avatar))
                avatar = "avatar.png";
            AvatarName = avatar;
        }

        public void SetActiveAddress(long addressId)
        {
            var currentAddress = Addresses.FirstOrDefault(q => q.Id == addressId);
            if (currentAddress == null)
            {
                throw new NullOrEmptyDomainDataException("آدرس پیدا نشد");
            }

            foreach (var address in Addresses)
            {
                address.SetActive();
            }

            currentAddress.SetActive();
        }
    }
}