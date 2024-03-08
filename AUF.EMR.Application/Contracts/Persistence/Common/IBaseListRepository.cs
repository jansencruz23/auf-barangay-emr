using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence.Common
{
    public interface IBaseListRepository : IGenericRepository<HouseholdMember>
    {
        Task<List<HouseholdMember>> GetListQuery(string householdNo, DateTime startDate);
        Task<List<HouseholdMember>> GetListQuery(string householdNo, DateTime startDate, DateTime endDate);
        Task<List<HouseholdMember>> GetAllList(string householdNo);
        Task<List<HouseholdMember>> GetAllList();
    }
}
