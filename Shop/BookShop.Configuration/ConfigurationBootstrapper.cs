using BookShop.Application._Utilities;
using BookShop.Application.Categories.Services;
using BookShop.Application.Comments.Services;
using BookShop.Application.Orders.Services;
using BookShop.Application.Products.Services;
using BookShop.Application.Roles.Add;
using BookShop.Application.Sellers.Services;
using BookShop.Application.Users.Services;
using BookShop.Domain.CategoryAgg.Services;
using BookShop.Domain.CommentAgg.Services;
using BookShop.Domain.OrderAgg.Services;
using BookShop.Domain.ProductAgg.Services;
using BookShop.Domain.SellerAgg.Services;
using BookShop.Domain.UserAgg.Services;
using BookShop.Infrastructure;
using BookShop.Query.Categories.GetById;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Configuration
{
    public static class ConfigurationBootstrapper
    {
        public static void RegisterDependency(this IServiceCollection services, string connectionString)
        {
            InfrastructureBootstrapper.Init(services, connectionString);
            services.AddMediatR(typeof(Directories).Assembly);
            services.AddMediatR(typeof(GetCategoryByIdQuery).Assembly);
            services.AddTransient(typeof(IUserDomainService), typeof(UserDomainService));
            services.AddTransient(typeof(IOrderDomainService), typeof(OrderDomainService));
            services.AddTransient(typeof(ISellerDomainService), typeof(SellerDomainService));
            services.AddTransient(typeof(IProductDomainService), typeof(ProductDomainService));
            services.AddTransient(typeof(ICommentDomainService), typeof(CommentDomainService));
            services.AddTransient(typeof(ICategoryDomainService), typeof(CategoryDomainService));
            services.AddValidatorsFromAssembly(typeof(AddRoleCommandValidator).Assembly);
        }
    }
}