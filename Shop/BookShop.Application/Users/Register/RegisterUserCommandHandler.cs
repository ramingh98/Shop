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

namespace BookShop.Application.Users.Register
{
    public class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDomainService _userDomainService;

        public RegisterUserCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService)
        {
            _userRepository = userRepository;
            _userDomainService = userDomainService;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.RegisterUser(request.PhoneNumber.Value, Sha256Hasher.Hash(request.Password), _userDomainService);
            await _userRepository.AddAsync(user);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}