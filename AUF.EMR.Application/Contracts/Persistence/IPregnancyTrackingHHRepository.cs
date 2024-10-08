﻿using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface IPregnancyTrackingHHRepository : IGenericRepository<PregnancyTrackingHH>
    {
        public Task<PregnancyTrackingHH> GetPregnancyTrackingHHWithDetails(int id);
        public Task<PregnancyTrackingHH> GetPregnancyTrackingHHWithDetails(string householdNo);
    }
}
