using System.Collections.Generic;
using Warehouse.DataAccess.Entities.Main;

namespace Warehouse.DataAccess.Repositories.Abstractions.Main
{
    public interface IMeatureTypeRepository:IGenericRepository<MeatureType>
    {
        Task<MeatureType> GetMeatureType(int id);
        Task<IEnumerable<MeatureType>> GetMeatureTypes();
    }
}
