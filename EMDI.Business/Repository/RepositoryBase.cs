using EMDI.Models;
using EMDI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMDI.Business.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected EDMIDBContext RepositoryContext { get; set; }

        public RepositoryBase(EDMIDBContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.RepositoryContext.Set<T>().ToListAsync();
        }

        public async Task<T> FindAsync(int id)
        {
            return await this.RepositoryContext.Set<T>().FindAsync(id);
        }

        public async Task<int> AddAsync(T item)
        {
            int rowsAffected = 0;

            this.RepositoryContext.Set<T>().Add(item);

            rowsAffected = await this.RepositoryContext.SaveChangesAsync();

            return rowsAffected;
        }

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
