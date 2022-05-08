using System.Net;
using BookShop.API.Infrastructures.Security;
using BookShop.Application.Categories.Add;
using BookShop.Application.Categories.AddChild;
using BookShop.Application.Categories.Edit;
using BookShop.Domain.RoleAgg.Enums;
using BookShop.Presentation.Facade.Categories;
using BookShop.Query.Categories.DTOs;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{
    [CheckPermission(Permission.CategoryManagement)]
    public class CategoryController : ApiController
    {
        private readonly ICategoryFacade _categoryFacade;

        public CategoryController(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<List<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryFacade.GetCategoriesAsync();
            return QueryResult(categories);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ApiResult<CategoryDto>> GetCategoryById(int id)
        {
            var category = await _categoryFacade.GetCategoryByIdAsync(id);
            return QueryResult(category);
        }

        [HttpGet("getChild/{parentId}")]
        public async Task<ApiResult<List<ChildCategoryDto>>> GetCategoriesByParentId(long parentId)
        {
            var categories = await _categoryFacade.GetCategoriesByParentIdAsync(parentId);
            return QueryResult(categories);
        }

        [HttpPost("AddCategory")]
        public async Task<ApiResult<long>> AddCategory(AddCategoryCommand command)
        {
            var result = await _categoryFacade.AddCategoryAsync(command);
            var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, HttpStatusCode.Created, url);
        }

        [HttpPost("AddChild")]
        public async Task<ApiResult<long>> AddCategory(AddChildCategoryCommand command)
        {
            var result = await _categoryFacade.AddChildAsync(command);
            var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, HttpStatusCode.Created, url);
        }

        [HttpPut]
        public async Task<ApiResult> EditCategory(EditCategoryCommand command)
        {
            var result = await _categoryFacade.EditCategoryAsync(command);
            return CommandResult(result);
        }
    }
}