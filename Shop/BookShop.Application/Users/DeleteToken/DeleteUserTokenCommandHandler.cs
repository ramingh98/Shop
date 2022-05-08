using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.UserAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Users.DeleteToken
{
    internal class DeleteUserTokenCommandHandler : IBaseCommandHandler<DeleteUserTokenCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserTokenCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationResult> Handle(DeleteUserTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
            {
                return OperationResult.NotFound();
            }

            user.DeleteToken(request.TokenId);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}