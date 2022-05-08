using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.UserAgg;
using BookShop.Domain.UserAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Users.EditAddress
{
    public class EditUserAddressCommandHandler : IBaseCommandHandler<EditUserAddressCommand>
    {
        private readonly IUserRepository _userRepository;

        public EditUserAddressCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<OperationResult> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
            {
                return OperationResult.NotFound();
            }
            var address = new UserAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress, request.PhoneNumber, request.Name, request.Family, request.NationalCode);
            user.EditAddress(address, request.Id);
            await _userRepository.Save();
            return OperationResult.Success();
        }
    }
}