using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CategoryAgg.Repositories;
using BookShop.Domain.CategoryAgg.Services;
using Common.Application;

namespace BookShop.Application.Categories.AddChild
{
    public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand, long>
    {
        private ICategoryRepository _repository;
        private ICategoryDomainService _domainService;

        public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }
        public async Task<OperationResult<long>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.ParentId);
            if (category == null)
            {
                return OperationResult<long>.NotFound();
            }
            category.AddChild(request.Title, request.Slug, request.SeoData, _domainService);
            await _repository.Save();
            return OperationResult<long>.Success(category.Id);
        }
    }
}