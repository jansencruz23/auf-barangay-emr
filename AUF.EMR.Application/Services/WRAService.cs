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
    public class WRAService : GenericService<WomanOfReproductiveAge>, IWRAService
    {
        private readonly IWRARepository _repository;

        public WRAService(IWRARepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<WomanOfReproductiveAge>> GetWRAWithDetails(string householdNo)
        {
            return await _repository.GetWRAWithDetails(householdNo);
        }
    }
}
