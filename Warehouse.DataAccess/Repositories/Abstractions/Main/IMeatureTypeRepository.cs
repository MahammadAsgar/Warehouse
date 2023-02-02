using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.DataAccess.Entities.Main;

namespace Warehouse.DataAccess.Repositories.Abstractions.Main
{
    public interface IMeatureTypeRepository:IGenericRepository<MeatureType>
    {
        Task<MeatureType> GetMeatureType(int id);
        Task<IEnumerable<MeatureType>> GetAllMeatureTypes();
        Task<IEnumerable<MeatureType>> GetActiveMeatureTypes();
    }
}
