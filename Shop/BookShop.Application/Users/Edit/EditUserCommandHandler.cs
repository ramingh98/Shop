using BookShop.Application._Utilities;
using BookShop.Domain.UserAgg.Repositories;
using BookShop.Domain.UserAgg.Services;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.Users.Edit;

public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    private readonly IUserDomainService _userDomainService;
    private readonly IUserRepository _userRepository;
    private readonly ILocalFileService _localFileService;

    public EditUserCommandHandler(IUserDomainService userDomainService, IUserRepository userRepository, ILocalFileService localFileService)
    {
        _userDomainService = userDomainService;
        _userRepository = userRepository;
        _localFileService = localFileService;
    }

    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.UserId);
        if (user == null)
        {
            return OperationResult.NotFound();
        }

        var oldAvatar = user.AvatarName;
        user.Edit(request.Name, request.Family, request.PhoneNumber, request.Email, request.Gender, _userDomainService);
        if (request.Avatar != null)
        {
            var avatar = await _localFileService.SaveFileAndGenerateName(request.Avatar, Directories.UserAvatars);
            user.SetAvatar(avatar);
        }

        DeleteOldAvatar(request.Avatar, oldAvatar);
        await _userRepository.Save();
        return OperationResult.Success();
    }

    private void DeleteOldAvatar(IFormFile? avatarFile, string oldAvatar)
    {
        if (avatarFile == null || oldAvatar == "avatar.png")
        {
            return;
        }
        _localFileService.DeleteFile(Directories.UserAvatars, oldAvatar);
    }
}