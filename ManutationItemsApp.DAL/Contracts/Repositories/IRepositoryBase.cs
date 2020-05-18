using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ManutationItemsApp.DAL.Contracts.Repositories
{
    public interface IRepositoryBase<T> where T:class 
    {
        IQueryable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        #region new methods for CROD operations
        /// <summary>
        /// Get specific object from database based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T</returns>
        T Get(int id);

        /// <summary>
        /// Get List of objects based on requirements, also include properties for linked objects
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns><T></returns>
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        /// <summary>
        /// Get specific object based on requirements, also include properties for linked objects
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns>T</returns>
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        /// <summary>
        /// Create new entity
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Remove a specific object based on id
        /// </summary>
        /// <param name="id"></param>
        void Remove(int id);

        /// <summary>
        /// Remove complete entity
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);

        /// <summary>
        /// Remove a range of entities
        /// </summary>
        /// <param name="entity"></param>
        void RemoveRange(IEnumerable<T> entity);
        #endregion
    }
}
