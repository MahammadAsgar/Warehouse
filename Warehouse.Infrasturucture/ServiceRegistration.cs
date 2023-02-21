using Microsoft.Extensions.DependencyInjection;
using Warehouse.Infrasturucture.Utilities.Security.Jwt;

namespace Warehouse.Infrasturucture
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, JwtHelper>();
        }
    }
}
