using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.CategoryAgg.Repositories;
using BookShop.Domain.CommentAgg.Repositories;
using BookShop.Domain.OrderAgg.Repositories;
using BookShop.Domain.ProductAgg.Repositories;
using BookShop.Domain.RoleAgg.Repositories;
using BookShop.Domain.SellerAgg.Repositories;
using BookShop.Domain.SiteEntities.Repositories;
using BookShop.Domain.UserAgg.Repositories;
using BookShop.Infrastructure.Persistent.Dapper;
using BookShop.Infrastructure.Persistent.EF;
using BookShop.Infrastructure.Persistent.EF.CategoryAgg;
using BookShop.Infrastructure.Persistent.EF.CommentAgg;
using BookShop.Infrastructure.Persistent.EF.OrderAgg;
using BookShop.Infrastructure.Persistent.EF.ProductAgg;
using BookShop.Infrastructure.Persistent.EF.RoleAgg;
using BookShop.Infrastructure.Persistent.EF.SellerAgg;
using BookShop.Infrastructure.Persistent.EF.SiteEntities.Repositories;
using BookShop.Infrastructure.Persistent.EF.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Infrastructure
{
    public class InfrastructureBootstrapper
    {
        public static void Init(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ISellerRepository, SellerRepository>();
            services.AddTransient<IBannerRepository, BannerRepository>();
            services.AddTransient<ISliderRepository, SliderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient(_ => new DapperContext(connectionString));
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
        }
    }
}