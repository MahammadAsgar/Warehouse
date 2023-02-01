using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using  Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Entities.Users;

namespace Warehouse.DataAccess.Context
{
    public class WarehouseDbContext :IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public WarehouseDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MeatureType> MeatureTypes { get; set; }
        public DbSet<Warehouse.DataAccess.Entities.Main.File> Files { get; set; }
    }
}
