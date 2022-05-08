using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.UserAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Users.DeleteAddress
{
    public class DeleteUserAddressCommandHandler : IBaseCommandHandler<DeleteUserAddressCommand>
    {
        private IUserRepository _userRepository;

        public DeleteUserAddressCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<OperationResult> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
            {
                return OperationResult.NotFound();
            }
            user.DeleteAddress(request.AddressId);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}
