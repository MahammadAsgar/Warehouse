﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Warehouse.DataAccess.Context;
using Warehouse.DataAccess.Entities.Base;

namespace Warehouse.DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private DbSet<TEntity> _dbset;
        protected readonly WarehouseDbContext _warehouseDbContext;

        public GenericRepository(WarehouseDbContext warehouseDbContext)
        {
            _dbset = warehouseDbContext.Set<TEntity>();
            _warehouseDbContext = warehouseDbContext;
        }

        public void Add(TEntity entity)
        {
            _dbset.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbset.Update(entity);
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbset.AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbset.AddRange(entities);
        }
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbset.UpdateRange(entities);
        }
        public void Attach(TEntity entity)
        {
            _dbset.Attach(entity);
        }

        public void AttachRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                Attach(entity);
        }

        public bool CheckExist(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbset.Any();

            return _dbset.Any(predicate);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbset.Count();

            return _dbset.Count(predicate);
        }

        public void Delete(TEntity entity)
        {
            _dbset.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var entity in GetAll(predicate))
                Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.SingleOrDefault(predicate);
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbset.SingleOrDefaultAsync(predicate);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbset.OrderBy(x => x.Id).ToList();

            return _dbset.Where(predicate).OrderBy(x => x.Id).ToList();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbset.OrderBy(x => x.Id).ToList();

            return await _dbset.Where(predicate).OrderBy(x => x.Id).ToListAsync();
        }
        public IQueryable<TEntity> GetAsQueryable()
        {
            return _dbset;
        }
        public void Reload(TEntity entity)
        {
            _warehouseDbContext.Entry<TEntity>(entity).Reload();
        }
    }
}
