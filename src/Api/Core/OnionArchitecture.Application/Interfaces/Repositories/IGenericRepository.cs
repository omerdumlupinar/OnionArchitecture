using OnionArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetAll(bool noTracking = true);
        List<TEntity> GetByIdAsync(int id, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);


        IQueryable<TEntity> AsQueryable();


        Task<int> AddAsync(TEntity entity);
        Task<int> AddAsync(IEnumerable<TEntity> entities);


        Task<int> UpdateAysnc(TEntity entity);


        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(TEntity entity);
        Task<bool> DeleteRangeAysnc(Expression<Func<TEntity, bool>> predicate);
    }
}
