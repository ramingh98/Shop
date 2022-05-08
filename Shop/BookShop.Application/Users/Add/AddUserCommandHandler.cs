using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.UserAgg;
using BookShop.Domain.UserAgg.Repositories;
using BookShop.Domain.UserAgg.Services;
using Common.Application;
using Common.Application.SecurityUtil;

namespace BookShop.Application.Users.Add
{
    public class AddUserCommandHandler : IBaseCommandHandler<AddUserCommand>
    {
        private readonly IUserDomainService _userDomainService;
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(IUserDomainService userDomainService, IUserRepository userRepository)
        {
            _userDomainService = userDomainService;
            _userRepository = userRepository;
        }
        public async Task<OperationResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var password = Sha256Hasher.Hash(request.Password);
            var user = new User(request.Name, request.Family, request.PhoneNumber, request.Email, password,
                request.Gender, _userDomainService);
            _userRepository.Add(user);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}