using Microsoft.Extensions.DependencyInjection;
using Nairobi.Data.Repositories;
using Nairobi.Data.Repositories.Interfaces;

namespace Nairobi.Extensions
{
    public static class RepositoryServices
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRespository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
