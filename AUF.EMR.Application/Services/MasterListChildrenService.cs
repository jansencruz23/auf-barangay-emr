using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Services
{
    public class MasterListChildrenService : GenericService<MasterListChildren>, IMasterListChildrenService
    {
        private readonly IMasterListChildrenRepository _repository;

        public MasterListChildrenService(IMasterListChildrenRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<MasterListChildren>> GetMasterListChildrenWithDetails(string householdNo)
        {
            return await _repository.GetMasterListChildrenWithDetails(householdNo);
        }

        public async Task<MasterListChildren> GetMasterListChildWithDetails(int id)
        {
            return await _repository.GetMasterListChildWithDetails(id);
        }
    }
}
