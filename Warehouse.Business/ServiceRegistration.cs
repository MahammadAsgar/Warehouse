using Microsoft.Extensions.DependencyInjection;
using Warehouse.Business.Mappings;
using Warehouse.Business.Services.Abstractions.Main;
using Warehouse.Business.Services.Abstractions.Storage;
using Warehouse.Business.Services.Implementations.Main;
using Warehouse.Business.Services.Implementations.Storage;

namespace Warehouse.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IStorage, FileStorage>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductFileService, ProductFileService>();
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
