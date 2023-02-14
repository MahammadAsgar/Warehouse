using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Entities.Users;

namespace Warehouse.DataAccess.Context
{
    public class WarehouseDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public WarehouseDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MeasureType> MeatureTypes { get; set; }
        public DbSet<Warehouse.DataAccess.Entities.Main.File> Files { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Selling> Sellings { get; set; }
        public DbSet<Buying> Buyings { get; set; }
        public DbSet<Warehouse.DataAccess.Entities.Main.Depot> Warehouses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<MeasuredProduct> MeasuredProducts { get; set; }

    }
}
