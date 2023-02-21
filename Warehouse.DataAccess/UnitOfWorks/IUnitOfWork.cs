using Warehouse.DataAccess.Entities.Base;
using Warehouse.DataAccess.Repositories;

namespace Warehouse.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : EntityBase;
        void Commit();
    }
}
