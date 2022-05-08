using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CategoryAgg;
using BookShop.Domain.CategoryAgg.Repositories;
using BookShop.Domain.CategoryAgg.Services;
using Common.Application;

namespace BookShop.Application.Categories.Add
{
    public class AddCategoryCommandHandler : IBaseCommandHandler<AddCategoryCommand, long>
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryDomainService _domainService;

        public AddCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult<long>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Title, request.Slug, request.SeoData, _domainService);
            await _repository.AddAsync(category);
            await _repository.Save();
            return OperationResult<long>.Success(category.Id);
        }
    }
}