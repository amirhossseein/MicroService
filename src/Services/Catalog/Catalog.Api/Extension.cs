using Catalog.Api.Data;
using Catalog.Api.Repositories;

namespace Catalog.Api
{
    public static class Extension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICatalogContext, CatalogContext>();
        }
    }
}
