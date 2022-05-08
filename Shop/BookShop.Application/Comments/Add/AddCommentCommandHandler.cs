using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CommentAgg;
using BookShop.Domain.CommentAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Comments.Add
{
    public class AddCommentCommandHandler : IBaseCommandHandler<AddCommentCommand>
    {
        private ICommentRepository _repository;

        public AddCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var comment = new Comment(request.UserId, request.ProductId, request.Text);
                _repository.Add(comment);
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
