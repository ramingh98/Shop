using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.UserAgg.Repositories;
using BookShop.Domain.UserAgg.Services;
using Common.Domain.ValueObjects;

namespace BookShop.Application.Users.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _userRepository;

        public UserDomainService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsEmailExist(string email)
        {
            return _userRepository.Exists(r => r.Email == email);
        }

        public bool IsPhoneNumberExist(string phoneNumber)
        {
            return _userRepository.Exists(r => r.PhoneNumber == phoneNumber);
        }
    }
}