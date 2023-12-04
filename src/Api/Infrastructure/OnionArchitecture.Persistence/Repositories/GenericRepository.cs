using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Interfaces.Repositories;
using OnionArchitecture.Domain.Models;
using OnionArchitecture.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly OnionArchitecture_Context _context;

        protected DbSet<TEntity> _entities => _context.Set<TEntity>();

        public GenericRepository(OnionArchitecture_Context context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddAsync(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }


        public IQueryable<TEntity> AsQueryable()
        {
            return _entities.AsQueryable();
        }


        public async Task<int> DeleteAsync(int id)
        {
            var entityToDelete = await _entities.FindAsync(id);
            if (entityToDelete != null)
            {
                _entities.Remove(entityToDelete);
                return await _context.SaveChangesAsync();
            }
            return 0; // İlgili ID'ye sahip varlık bulunamazsa 0 dönebilirsiniz.
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _entities.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteRangeAysnc(Expression<Func<TEntity, bool>> predicate)
        {
            var entitiesToDelete = _entities.Where(predicate);
            if (entitiesToDelete.Any())
            {
                _entities.RemoveRange(entitiesToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false; // Veri tabanında silinecek varlık bulunamazsa false dönebilirsiniz.
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _entities.AsQueryable();

            if (noTracking)
                query = query.AsNoTracking();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetAll(bool noTracking = true)
        {
            var query = _entities.AsQueryable();

            if (noTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public List<TEntity> GetByIdAsync(int id, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _entities.AsQueryable();

            if (noTracking)
                query = query.AsNoTracking();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.Where(e => e.Id == id).ToList();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _entities.AsQueryable();

            if (noTracking)
                query = query.AsNoTracking();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.Where(predicate).ToList();
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _entities.AsQueryable();

            if (noTracking)
                query = query.AsNoTracking();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.Where(predicate).ToListAsync();
        }

        public async Task<int> UpdateAysnc(TEntity entity)
        {
            _entities.Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
