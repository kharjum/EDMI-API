using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMDI.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> GetAllAsync();

        Task<T> FindAsync(int id);

        Task<int> AddAsync(T item);

        Task<int> UpdateAsync(T dbItem, T item);

        Task<int> DeleteAsync(int id);
    }
}
