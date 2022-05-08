using BookShop.API.Infrastructures.Security;
using BookShop.Application.Comments.Add;
using BookShop.Application.Comments.ChangeStatus;
using BookShop.Application.Comments.Edit;
using BookShop.Domain.RoleAgg.Enums;
using BookShop.Presentation.Facade.Comments;
using BookShop.Query.Comments.DTOs;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{

    public class CommentController : ApiController
    {
        private readonly ICommentFacade _commentFacade;

        public CommentController(ICommentFacade commentFacade)
        {
            _commentFacade = commentFacade;
        }

        [CheckPermission(Permission.CommentManagement)]
        [HttpGet]
        public async Task<ApiResult<CommentFilterResult>> GetCommentsByFilterTask([FromQuery] CommentFilterParam param)
        {
            var result = await _commentFacade.GetCommentsByFilterAsync(param);
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<CommentDto>> GetCommentById(long id)
        {
            var result = await _commentFacade.GetCommentByIdAsync(id);
            return QueryResult(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<ApiResult> AddComment(AddCommentCommand command)
        {
            var result = await _commentFacade.AddCommentAsync(command);
            return CommandResult(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<ApiResult> EditComment(EditCommentCommand command)
        {
            var result = await _commentFacade.EditCommentAsync(command);
            return CommandResult(result);
        }

        [CheckPermission(Permission.CrudBanner)]
        [HttpPut("changeStatus")]
        public async Task<ApiResult> ChangeCommentStatus(ChangeCommentStatusCommand command)
        {
            var result = await _commentFacade.ChangeStatusAsync(command);
            return CommandResult(result);
        }
    }
}