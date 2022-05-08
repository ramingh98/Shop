using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CommentAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Comments.ChangeStatus
{
    public class ChangeCommentStatusCommandHandler : IBaseCommandHandler<ChangeCommentStatusCommand>
    {
        private ICommentRepository _repository;

        public ChangeCommentStatusCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(ChangeCommentStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var comment = await _repository.GetTracking(request.Id);
                if (comment == null)
                {
                    return OperationResult.NotFound();
                }
                comment.ChangeStatus(request.Status);
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
