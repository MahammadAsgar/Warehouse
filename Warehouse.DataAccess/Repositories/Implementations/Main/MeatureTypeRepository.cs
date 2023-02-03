using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccess.Context;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Repositories.Abstractions.Main;

namespace Warehouse.DataAccess.Repositories.Implementations.Main
{
    public class MeatureTypeRepository : GenericRepository<MeasureType>, IMeatureTypeRepository
    {
        public MeatureTypeRepository(WarehouseDbContext warehouseDbContext) : base(warehouseDbContext)
        {
        }

        public async Task<MeasureType> GetMeatureType(int id)
        {
            return await GetAsQueryable()
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<MeasureType>> GetAllMeatureTypes()
        {
            return await GetAsQueryable()
                .Include(x => x.Products)
                .ToListAsync();
        } 
        
        public async Task<IEnumerable<MeasureType>> GetActiveMeatureTypes()
        {
            return await GetAsQueryable()
                .Include(x => x.Products)
                .Where(x=>x.IsActive==true)
                .ToListAsync();
        }
    }
}
