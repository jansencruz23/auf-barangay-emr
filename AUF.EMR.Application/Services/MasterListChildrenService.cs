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
    public class MasterlistChildrenService : GenericService<MasterlistChildren>, IMasterlistChildrenService
    {
        private readonly IMasterlistChildrenRepository _repository;

        public MasterlistChildrenService(IMasterlistChildrenRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<MasterlistChildren>> GetMasterlistChildrenWithDetails(string householdNo)
        {
            return await _repository.GetMasterlistChildrenWithDetails(householdNo);
        }

        public async Task<MasterlistChildren> GetMasterlistChildWithDetails(int id)
        {
            return await _repository.GetMasterlistChildWithDetails(id);
        }
    }
}
