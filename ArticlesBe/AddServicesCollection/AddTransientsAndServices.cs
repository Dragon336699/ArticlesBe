using ArticlesBe.Interfaces;
using ArticlesBe.Services;
using DataAccess.DbContext;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.UnitOfWork;

namespace ArticlesBe.AddServicesCollection
{
    public static class AddTransientsAndServices
    {
        public static void ConfigureLife(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ISubCategoriesRepository, SubCategoriesRepository>();
            services.AddScoped<IArticlesRepository, ArticlesRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CategoriesService>();
            services.AddScoped<SubCategoriesService>();
            services.AddScoped<ArticlesService>();    
            services.AddHttpContextAccessor();
        }
    }
}
