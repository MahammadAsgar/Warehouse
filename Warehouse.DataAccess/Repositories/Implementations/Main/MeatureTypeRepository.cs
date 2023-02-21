using Microsoft.EntityFrameworkCore;
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
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<MeasureType>> GetAllMeatureTypes()
        {
            return await GetAsQueryable()
                .ToListAsync();
        }

        public async Task<IEnumerable<MeasureType>> GetActiveMeatureTypes()
        {
            return await GetAsQueryable()
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }
    }
}
