using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Application.Contracts.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Services.Common
{
    public class GenericService<T> : IGenericService<T>
        where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<T> Add(T entity)
        {
            return await _repository.Add(entity);
        }

        public async Task Delete(T entity)
        {
            await _repository.Delete(entity);
        }

        public async Task Update(T entity)
        {
            await _repository.Update(entity);
        }

        public Task<bool> Exists(int id)
        {
            return _repository.Exists(id);
        }
    }
}
