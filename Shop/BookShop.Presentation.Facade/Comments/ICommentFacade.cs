using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Comments.Add;
using BookShop.Application.Comments.ChangeStatus;
using BookShop.Application.Comments.Edit;
using BookShop.Query.Comments.DTOs;
using BookShop.Query.Comments.GetByFilter;
using Common.Application;

namespace BookShop.Presentation.Facade.Comments
{
    public interface ICommentFacade
    {
        Task<OperationResult> AddCommentAsync(AddCommentCommand command);
        Task<OperationResult> EditCommentAsync(EditCommentCommand command);
        Task<OperationResult> ChangeStatusAsync(ChangeCommentStatusCommand command);
        Task<CommentDto> GetCommentByIdAsync(long id);
        Task<CommentFilterResult> GetCommentsByFilterAsync(CommentFilterParam param);
    }
}