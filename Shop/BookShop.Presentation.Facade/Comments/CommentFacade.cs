using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Comments.Add;
using BookShop.Application.Comments.ChangeStatus;
using BookShop.Application.Comments.Edit;
using BookShop.Query.Comments.DTOs;
using BookShop.Query.Comments.GetByFilter;
using BookShop.Query.Comments.GetById;
using Common.Application;
using MediatR;

namespace BookShop.Presentation.Facade.Comments
{
    internal class CommentFacade : ICommentFacade
    {
        private readonly IMediator _mediator;

        public CommentFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddCommentAsync(AddCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditCommentAsync(EditCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> ChangeStatusAsync(ChangeCommentStatusCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<CommentDto> GetCommentByIdAsync(long id)
        {
            return await _mediator.Send(new GetCommentByIdQuery(id));
        }

        public async Task<CommentFilterResult> GetCommentsByFilterAsync(CommentFilterParam param)
        {
            return await _mediator.Send(new GetCommentByFilterQuery(param));
        }
    }
}