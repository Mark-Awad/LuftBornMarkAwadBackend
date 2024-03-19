using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornBackendCore.IRepositry
{

        public interface IGenericRepository<TEntity, TContext> where TEntity : class
        {
            Task<IEnumerable<TEntity>> GetAllAsync(
                Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                Func<IQueryable<TEntity>, IQueryable<TEntity>> includeProperties = null);

            Task<TEntity> FirstOrDefaultAsync(
                Expression<Func<TEntity, bool>>? filter = null,
                Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeProperties = null);
            Task<TEntity> GetByIdAsync(object id);
            Task InsertAsync(TEntity entity);
            void Update(TEntity entity);
            void Delete(object id);
            Task SaveAsync();
            Task RollbackAsync();



        }
    }

