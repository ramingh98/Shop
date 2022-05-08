using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CategoryAgg.Repositories;
using BookShop.Domain.CategoryAgg.Services;
using Common.Application;

namespace BookShop.Application.Categories.Edit
{
    public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
    {
        private ICategoryRepository _repository;
        private ICategoryDomainService _domainService;

        public EditCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }
        public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _repository.GetTracking(request.Id);
                if (category == null)
                {
                    return OperationResult.NotFound();
                }
                category.Edit(request.Title, request.Slug, request.SeoData, _domainService);
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
