using Microsoft.Extensions.DependencyInjection;
using Warehouse.Business.Mappings;
using Warehouse.Business.Services.Abstractions;
using Warehouse.Business.Services.Implementations;

namespace Warehouse.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMeatureTypeService, MeatureTypeService>();

            services.AddAutoMapper(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MapProfile>();
            });
        }
    }
}
