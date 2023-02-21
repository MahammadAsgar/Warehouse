using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccess.Entities.Main;

namespace Warehouse.DataAccess.Repositories.Abstractions.Main
{
    public interface ICompanyRepository:IGenericRepository<Company>
    {
        Task<Company> GetCompany(int id);
        Task<Company> GetCompanyByUser(int userId);
        Task<IEnumerable<Company>> GetCompanies();
    }
}
