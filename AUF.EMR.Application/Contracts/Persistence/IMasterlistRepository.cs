using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface IMasterlistRepository : IGenericRepository<HouseholdMember>
    {
        Task<List<HouseholdMember>> GetMasterlistQuery(string householdNo, DateTime startDate);
        Task<List<HouseholdMember>> GetMasterlistQuery(string householdNo, DateTime startDate, DateTime endDate);
        Task<List<HouseholdMember>> GetAllMasterlist(string householdNo);
    }
}
