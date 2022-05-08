using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.UserAgg.Repositories;
using Common.Application;
using Common.Application.SecurityUtil;

namespace BookShop.Application.Users.ChangePassword
{
    internal class ChangeUserPasswordCommandHandler : IBaseCommandHandler<ChangeUserPasswordCommand>
    {
        private IUserRepository _userRepository;

        public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
            {
                return OperationResult.NotFound();
            }

            var currentPasswordHash = Sha256Hasher.Hash(request.CurrentPassword);
            if (user.Password != currentPasswordHash)
            {
                return OperationResult.Error("کلمه عبور فعلی نامعتبر است");
            }

            var newPassword = Sha256Hasher.Hash(request.Password);
            user.ChangePassword(newPassword);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}