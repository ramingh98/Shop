using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CommentAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Comments.Edit
{
    public class EditCommentCommandHandler : IBaseCommandHandler<EditCommentCommand>
    {
        private ICommentRepository _repository;

        public EditCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var comment = await _repository.GetTracking(request.CommentId);
                if (comment == null || comment.UserId != request.UserId)
                {
                    return OperationResult.NotFound();
                }
                comment.Edit(request.Text);
                await _repository.Save();
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
    }
}
