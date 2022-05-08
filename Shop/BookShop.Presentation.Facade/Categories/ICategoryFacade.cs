using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Categories.Add;
using BookShop.Application.Categories.AddChild;
using BookShop.Application.Categories.Edit;
using BookShop.Query.Categories.DTOs;
using Common.Application;

namespace BookShop.Presentation.Facade.Categories
{
    public interface ICategoryFacade
    {
        Task<OperationResult<long>> AddChildAsync(AddChildCategoryCommand command);
        Task<OperationResult<long>> AddCategoryAsync(AddCategoryCommand command);
        Task<OperationResult> EditCategoryAsync(EditCategoryCommand command);
        Task<OperationResult> DeleteCategoryAsync(long categoryId);
        Task<List<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(long id);
        Task<List<ChildCategoryDto>> GetCategoriesByParentIdAsync(long id);
    }
}