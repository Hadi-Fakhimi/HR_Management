using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T:class
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Exist(int id);
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);

    }
}
