using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services.Common
{
    public interface IGenericService<T>
        where T : class
    {
        Task<T> Get(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        Task AddRange(List<T> entities);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task<bool> Exists(int id);
    }
}
