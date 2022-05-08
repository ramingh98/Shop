using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Categories.Add;
using BookShop.Application.Categories.AddChild;
using BookShop.Application.Categories.Edit;
using BookShop.Application.Categories.Delete;
using BookShop.Query.Categories.DTOs;
using BookShop.Query.Categories.GetById;
using BookShop.Query.Categories.GetByParentId;
using BookShop.Query.Categories.GetList;
using Common.Application;
using MediatR;

namespace BookShop.Presentation.Facade.Categories
{
    internal class CategoryFacade : ICategoryFacade
    {
        private readonly IMediator _mediator;

        public CategoryFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult<long>> AddChildAsync(AddChildCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult<long>> AddCategoryAsync(AddCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditCategoryAsync(EditCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteCategoryAsync(long categoryId)
        {
            return await _mediator.Send(new DeleteCategoryCommand(categoryId));
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            return await _mediator.Send(new GetCategoryListQuery());
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(long id)
        {
            return await _mediator.Send(new GetCategoryByIdQuery(id));
        }

        public async Task<List<ChildCategoryDto>> GetCategoriesByParentIdAsync(long id)
        {
            return await _mediator.Send(new GetCategoryByParentIdQuery(id));
        }
    }
}