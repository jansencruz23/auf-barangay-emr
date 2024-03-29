﻿using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence.Repositories.Common
{
    public class BaseListRepository : GenericRepository<HouseholdMember>, IBaseListRepository
    {
        private readonly EMRDbContext _dbContext;

        public BaseListRepository(EMRDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HouseholdMember>> GetAllList(string householdNo)
        {
            var masterlist = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status)
                .Where(m => m.HouseholdNo.Equals(householdNo) && m.Status)
                .ToListAsync();

            return masterlist;
        }

        public Task<List<HouseholdMember>> GetAllList()
        {
            throw new NotImplementedException();
        }

        public async Task<List<HouseholdMember>> GetListQuery(string householdNo, DateTime startDate)
        {
            var newborns = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status)
                .Where(m => m.HouseholdNo.Equals(householdNo) && m.Status)
                .Where(m => m.Birthday >= startDate && m.Birthday <= DateTime.Today)
                .ToListAsync();

            return newborns;
        }

        public async Task<List<HouseholdMember>> GetListQuery(string householdNo, DateTime startDate, DateTime endDate)
        {
            var newborns = await _dbContext.HouseHoldMembers
                .AsNoTracking()
                .Include(m => m.Household)
                .Where(m => m.Household.Status)
                .Where(m => m.HouseholdNo.Equals(householdNo) && m.Status)
                .Where(m => m.Birthday >= startDate && m.Birthday <= endDate)
                .ToListAsync();

            return newborns;
        }
    }
}
