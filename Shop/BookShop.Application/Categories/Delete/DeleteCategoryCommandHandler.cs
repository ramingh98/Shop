using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CategoryAgg.Repositories;
using Common.Application;

namespace BookShop.Application.Categories.Delete
{
    internal class DeleteCategoryCommandHandler : IBaseCommandHandler<DeleteCategoryCommand>
    {
        private ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<OperationResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.DeleteCategory(request.CategoryId);
            if (!result)
            {
                return OperationResult.Error("عملیات حذف انجام نیافت");
            }

            return OperationResult.Success();
        }
    }
}