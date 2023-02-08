using Microsoft.Extensions.DependencyInjection;
using Warehouse.Business.Mappings;
using Warehouse.Business.Services.Abstractions.Main;
using Warehouse.Business.Services.Abstractions.Storage;
using Warehouse.Business.Services.Abstractions.User;
using Warehouse.Business.Services.Implementations.Main;
using Warehouse.Business.Services.Implementations.Storage;
using Warehouse.Business.Services.Implementations.User;

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
            services.AddScoped<ISellingService, SellingService>();
            services.AddScoped<IBuyingService, BuyingService>();
            services.AddScoped<IDepotService, DepotService>();
            services.AddScoped<IStockService, StockService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMailService, MailService>();

            services.AddAutoMapper(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MapProfile>();
            });
        }
    }
}
