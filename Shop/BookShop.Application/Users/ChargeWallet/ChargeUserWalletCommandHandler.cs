using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.UserAgg;
using BookShop.Domain.UserAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Users.ChargeWallet
{
    public class ChargeUserWalletCommandHandler : IBaseCommandHandler<ChargeUserWalletCommand>
    {
        private IUserRepository _userRepository;

        public async Task<OperationResult> Handle(ChargeUserWalletCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
            {
                return OperationResult.NotFound();
            }

            var wallet = new Wallet(request.Price, request.Description, request.IsFinally, request.Type);
            user.ChargeWallet(wallet);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}
