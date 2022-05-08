using BookShop.API.Infrastructures.JwtUtil;

namespace BookShop.API.Infrastructures
{
    public static class RegisterDependency
    {
        public static void RegisterApiDependency(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapProfile).Assembly);
            services.AddTransient<JwtValidation>();
            services.AddCors(option =>
            {
                option.AddPolicy(name: "Shop", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod();
                });
            });
        }
    }
}