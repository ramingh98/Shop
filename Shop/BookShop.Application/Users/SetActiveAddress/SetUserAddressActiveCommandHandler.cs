using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.UserAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Users.SetActiveAddress
{
    internal class SetUserAddressActiveCommandHandler : IBaseCommandHandler<SetUserAddressActiveCommand>
    {
        private IUserRepository _userRepository;

        public SetUserAddressActiveCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(SetUserAddressActiveCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
            {
                return OperationResult.NotFound();
            }

            user.SetActiveAddress(request.AddressId);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}