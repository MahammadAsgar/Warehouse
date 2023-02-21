using Warehouse.DataAccess.Entities.Main;

namespace Warehouse.DataAccess.Repositories.Abstractions.Main
{
    public interface IMeatureTypeRepository : IGenericRepository<MeasureType>
    {
        Task<MeasureType> GetMeatureType(int id);
        Task<IEnumerable<MeasureType>> GetAllMeatureTypes();
        Task<IEnumerable<MeasureType>> GetActiveMeatureTypes();
    }
}
