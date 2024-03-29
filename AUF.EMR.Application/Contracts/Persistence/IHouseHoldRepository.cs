﻿using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface IHouseholdRepository : IGenericRepository<Household>
    {
        Task<List<Household>> GetHouseholdsWithDetails();
        Task<List<Household>> GetSearchedHouseholdsWithDetails(string query);
        Task<List<Household>> GetSearchedHouseholdWithDetails(string query);
        Task<Household> GetHouseholdWithDetails(int id);
        Task<int> GetHouseholdId(string houseHoldNo);
    }
}
