using EMDI.Business.Entities;
using EMDI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMDI.Business.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Database Context
        /// </summary>
        protected EDMIDBContext RepositoryContext { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repositoryContext"></param>
        public RepositoryBase(EDMIDBContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        /// <summary>
        /// Get all Items
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetAllAsync()
        {
            return await this.RepositoryContext.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Get Item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> FindAsync(int id)
        {
            return await this.RepositoryContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Add new Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(T item)
        {
            int rowsAffected = 0;

            this.RepositoryContext.Set<T>().Add(item);

            rowsAffected = await this.RepositoryContext.SaveChangesAsync();

            return rowsAffected;
        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="dbItem"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(T dbItem, T item)
        {
            int rowsAffected = 0;

            // detach
            this.RepositoryContext.Entry<T>(dbItem).State = EntityState.Detached;

            // set Modified flag in your entry
            this.RepositoryContext.Entry<T>(item).State = EntityState.Modified;

            rowsAffected = await this.RepositoryContext.SaveChangesAsync();

            return rowsAffected;
        }

        /// <summary>
        /// Delete Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(int id)
        {
            int rowsAffected = 0;

            T item = await this.RepositoryContext.Set<T>().FindAsync(id);

            this.RepositoryContext.Set<T>().Remove(item);

            rowsAffected = await this.RepositoryContext.SaveChangesAsync();

            return rowsAffected;
        }
    }
}
