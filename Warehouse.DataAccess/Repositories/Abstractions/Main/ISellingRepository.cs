using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccess.Entities.Main;

namespace Warehouse.DataAccess.Repositories.Abstractions.Main
{
    public interface ISellingRepository : IGenericRepository<Selling>
    {
        Task<Selling> GetSelling(int id);
        Task<IEnumerable<Selling>> GetAllSellings();
        Task<IEnumerable<Selling>> GetActiveSellings();
        Task<IEnumerable<Selling>> GetSellingsByUser(int userId);
    }
}
