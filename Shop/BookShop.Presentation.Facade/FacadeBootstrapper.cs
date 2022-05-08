using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Presentation.Facade.Categories;
using BookShop.Presentation.Facade.Comments;
using BookShop.Presentation.Facade.Orders;
using BookShop.Presentation.Facade.Products;
using BookShop.Presentation.Facade.Roles;
using BookShop.Presentation.Facade.Sellers;
using BookShop.Presentation.Facade.Sellers.Inventories;
using BookShop.Presentation.Facade.SiteEntities.Banners;
using BookShop.Presentation.Facade.SiteEntities.Sliders;
using BookShop.Presentation.Facade.Users;
using BookShop.Presentation.Facade.Users.Addresses;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Presentation.Facade
{
    public static class FacadeBootstrapper
    {
        public static void Init(this IServiceCollection services)
        {
            services.AddScoped<IRoleFacade, RoleFacade>();
            services.AddScoped<IUserFacade, UserFacade>();
            services.AddScoped<IOrderFacade, OrderFacade>();
            services.AddScoped<ISliderFacade, SliderFacade>();
            services.AddScoped<IBannerFacade, BannerFacade>();
            services.AddScoped<ISellerFacade, SellerFacade>();
            services.AddScoped<ICommentFacade, CommentFacade>();
            services.AddScoped<IProductFacade, ProductFacade>();
            services.AddScoped<ICategoryFacade, CategoryFacade>();
            services.AddScoped<IUserAddressFacade, UserAddressFacade>();
            services.AddScoped<ISellerInventoryFacade, SellerInventoryFacade>();
        }
    }
}