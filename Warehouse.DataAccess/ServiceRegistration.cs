using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccess.Context;
using Warehouse.DataAccess.Repositories;
using Warehouse.DataAccess.Repositories.Abstractions.Main;
using Warehouse.DataAccess.Repositories.Implementations.Main;
using Warehouse.DataAccess.UnitOfWorks;

namespace Warehouse.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
           // Builder.Services.AddDbContext<WarehouseDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WarehouseDbConnection")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMeatureTypeRepository, MeatureTypeRepository>();
        }
    }
}
